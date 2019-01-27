using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Image_Editor
{
    public partial class Form1 : Form
    {
        #region Fields

        private const string cmArtistic = "Artistic";
        private const string cmDramatic = "Dramatic";
        private const string cmFlash = "Flash";
        private const string cmFrozen = "Frozen";
        private const string cmGray = "Gray";
        private const string cmHue = "Hue";
        private const string cmKakao = "Kakao";
        private const string cmSepia = "Sepia";
        private const string cmSpike = "Spike";
        private const string cmSuji = "Suji";
        private Image mFile;
        private Bitmap mInvertedBitmap;

        private int mCurrentImageIndex;

        private readonly List<string> mExcludedButtons = new List<string>();
        private readonly List<Image> mUndoRedoImages = new List<Image>();
        private readonly List<Button> mSelectedFilters = new List<Button>();

        private Button mSelectedFilter;

        private readonly ImageAttributes mImageAttributes = new ImageAttributes();

        #endregion Fields

        #region Constructors

        public Form1()
        {
            InitializeComponent();

            //to add the scroll bar to panel
            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;

            PopulateExcludedList();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the change blue.
        /// </summary>
        /// <value>
        /// The change blue.
        /// </value>
        private float ChangeBlue => bluebar.Value * 0.1f;

        /// <summary>
        /// Gets the change green.
        /// </summary>
        /// <value>
        /// The change green.
        /// </value>
        private float ChangeGreen => greenbar.Value * 0.1f;

        /// <summary>
        /// Gets the change red.
        /// </summary>
        /// <value>
        /// The change red.
        /// </value>
        private float ChangeRed => redbar.Value * 0.1f;

        /// <summary>
        /// Gets the graphics.
        /// </summary>
        /// <value>
        /// The graphics.
        /// </value>
        private Graphics Graphics => Graphics.FromImage(mInvertedBitmap);

        #endregion Properties

        #region Filters

        /// <summary>
        /// Applies the artistic filter.
        /// </summary>
        private void Artistic()
        {
            mImageAttributes.SetColorMatrix(GetColorMatrix(cmArtistic));

            DrawImage(ArtisticButton);
        }

        /// <summary>
        /// Applies the dramatic filter
        /// </summary>
        private void Dramatic()
        {
            mImageAttributes.SetColorMatrix(GetColorMatrix(cmDramatic));

            DrawImage(DramaticButton);
        }

        /// <summary>
        /// Applies the flash filter
        /// </summary>
        private void Flash()
        {
            mImageAttributes.SetColorMatrix(GetColorMatrix(cmFlash));

            DrawImage(FlashButton);
        }

        /// <summary>
        /// Applies spike on image.
        /// </summary>
        private void Spike()
        {
            mImageAttributes.SetColorMatrix(GetColorMatrix(cmSpike));

            DrawImage(SpikeButton);
        }

        /// <summary>
        /// Applies the frozen filter
        /// </summary>
        private void Frozen()
        {
            mImageAttributes.SetColorMatrix(GetColorMatrix(cmFrozen));

            DrawImage(FrozenButton);
        }

        /// <summary>
        /// Applies gray filter.
        /// </summary>
        private void GrayScale()
        {
            mImageAttributes.SetColorMatrix(GetColorMatrix(cmGray));

            DrawImage(GrayButton);
        }

        /// <summary>
        /// Applies hue on the image
        /// </summary>
        private void Hue()
        {
            if (mSelectedFilter != null)
            {
                mSelectedFilter.BackColor = Color.LightGray;
            }

            redvalue.Text = ChangeRed.ToString(CultureInfo.InvariantCulture);
            bluevalue.Text = ChangeGreen.ToString(CultureInfo.InvariantCulture);
            greenvalue.Text = ChangeBlue.ToString(CultureInfo.InvariantCulture);

            Reload();

            mImageAttributes.SetColorMatrix(GetColorMatrix(cmHue));

            DrawImage(null);
        }

        /// <summary>
        /// Applies kakao filter
        /// </summary>
        private void Kakao()
        {
            mImageAttributes.SetColorMatrix(GetColorMatrix(cmKakao));

            DrawImage(KakaoButton);
        }

        /// <summary>
        /// Applies the sepia filter
        /// </summary>
        private void Sepia()
        {
            mImageAttributes.SetColorMatrix(GetColorMatrix(cmSepia));

            DrawImage(SepiaButton);
        }

        /// <summary>
        /// Applies the suji filter
        /// </summary>
        private void Suji()
        {
            mImageAttributes.SetColorMatrix(GetColorMatrix(cmSuji));

            DrawImage(SujiButton);
        }

        #endregion Filters

        #region Helper methods

        /// <summary>
        /// Draws the histogram.
        /// </summary>
        /// <param name="HistogramValues">The histogram values.</param>
        private void DrawHistogram(Dictionary<int, int> HistogramValues)
        {
            Histogram.Series.Clear();

            var series1 = new Series
            {
                Name = "Histogram",
                Color = Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.StackedColumn
            };

            Histogram.Series.Add(series1);

            for (var i = 0; i < HistogramValues.Count; i++)
            {
                series1.Points.AddXY(HistogramValues.Keys.ElementAt(i), HistogramValues.Values.ElementAt(i));
            }
            Histogram.Invalidate();
            Histogram.SaveImage(HistogramImagePath, ChartImageFormat.Jpeg);
            var local = new Bitmap(HistogramImagePath);
            pictureBox1.Image = local;
        }

        /// <summary>
        /// Populates the expander list.
        /// </summary>
        private void PopulateExcludedList()
        {
            mExcludedButtons.Add(FiltersExpander.Text);
            mExcludedButtons.Add(UndoRedoExpander.Text);
            mExcludedButtons.Add(UndoButton.Text);
            mExcludedButtons.Add(RedoButton.Text);
            mExcludedButtons.Add(HistogramButton.Text);
            mExcludedButtons.Add(ResizeExpander.Text);
        }

        /// <summary>
        /// Gets the background path.
        /// </summary>
        /// <value>
        /// The background path.
        /// </value>
        private static string BackgroundPath
        {
            get
            {
                var process = Process.GetCurrentProcess();
                var full_path = process.MainModule.FileName;

                var application_folder = full_path.Replace(@"\Image Editor.exe", "");

                return $@"{application_folder}\Resources\FirstImage.jpg";
            }
        }

        /// <summary>
        /// Gets the background path.
        /// </summary>
        /// <value>
        /// The background path.
        /// </value>
        private static string HistogramImagePath
        {
            get
            {
                var process = Process.GetCurrentProcess();
                var full_path = process.MainModule.FileName;

                var application_folder = full_path.Replace(@"\Image Editor.exe", "");

                return $@"{application_folder}\Resources\Histogram.jpg";
            }
        }

        /// <summary>
        /// Enables the button.
        /// </summary>
        /// <param name="Button">The button.</param>
        /// <param name="ColorName">Name of the color.</param>
        private void EnableButton(Control Button, string ColorName = "")
        {
            Button.Enabled = true;

            Button.BackColor = string.IsNullOrEmpty(ColorName) ? Color.LightGray : Color.FromName(ColorName);
        }

        private void DisableButton(Control Button, string ColorName = "")
        {
            Button.Enabled = false;
            Button.BackColor = string.IsNullOrEmpty(ColorName) ? Color.Gray : Color.FromName(ColorName);
        }

        /// <summary>
        /// Draws the image.
        /// </summary>
        private void DrawImage(Button FilterName, int DesiredWidth = 0, int DesiredHeight = 0)
        {
            if (DesiredHeight == 0 || DesiredWidth == 0)
            {
                DesiredWidth = mFile.Width;
                DesiredHeight = mFile.Height;
            }

            Graphics.DrawImage(mFile, new Rectangle(0, 0, DesiredWidth, DesiredHeight), 0, 0, mFile.Width, mFile.Height, GraphicsUnit.Pixel, mImageAttributes);
            Graphics.Dispose();
            pictureBox1.Image = mInvertedBitmap;
            mUndoRedoImages.Add(mInvertedBitmap);
            mSelectedFilters.Add(FilterName ?? NoneButton);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        /// <summary>
        /// Gets the color matrix.
        /// </summary>
        /// <param name="SpecificFilter">The specific filter.</param>
        /// <returns></returns>
        private ColorMatrix GetColorMatrix(string SpecificFilter)
        {
            switch (SpecificFilter)
            {
                case cmArtistic:
                    return new ColorMatrix(
                        new[]
                        {
                            new float[] {1, 0, 0, 0, 0},
                            new float[] {0, 1, 0, 0, 0},
                            new float[] {0, 0, 1, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 1, 0, 1}
                        });

                case cmSepia:
                    return new ColorMatrix(
                        new[]
                        {
                            new[] {.393f, .349f, .272f, 0, 0},
                            new[] {.769f, .686f, .534f, 0, 0},
                            new[] {.189f, .168f, .131f, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 0, 0, 1}
                        });

                case cmGray:
                    return new ColorMatrix(
                        new[]
                        {
                            new[] {0.299f, 0.299f, 0.299f, 0, 0},
                            new[] {0.587f, 0.587f, 0.587f, 0, 0},
                            new[] {0.114f, 0.114f, 0.114f, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 0, 0, 0}
                        });

                case cmSpike:
                    return new ColorMatrix(
                        new[]
                        {
                            new[] {1 + 0.3f, 0, 0, 0, 0},
                            new[] {0, 1 + 0.7f, 0, 0, 0},
                            new[] {0, 0, 1 + 1.3f, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 0, 0, 1}
                        });

                case cmFlash:
                    return new ColorMatrix(
                        new[]
                        {
                            new[] {1 + 0.9f, 0, 0, 0, 0},
                            new[] {0, 1 + 1.5f, 0, 0, 0},
                            new[] {0, 0, 1 + 1.3f, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 0, 0, 1}
                        });

                case cmHue:
                    return new ColorMatrix(new[]
                    {
                        new[] {1 + ChangeRed, 0, 0, 0, 0},
                        new[] {0, 1 + ChangeGreen, 0, 0, 0},
                        new[] {0, 0, 1 + ChangeBlue, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                    });

                case cmFrozen:
                    return new ColorMatrix(
                         new[]
                         {
                            new[] {1 + 0.3f, 0, 0, 0, 0},
                            new[] {0, 1 + 0f, 0, 0, 0},
                            new[] {0, 0, 1 + 5f, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 0, 0, 1}
                         });

                case cmSuji:
                    return new ColorMatrix(
                         new[]
                         {
                            new[] {.393f, .349f + 0.5f, .272f, 0, 0},
                            new[] {.769f + 0.3f, .686f, .534f, 0, 0},
                            new[] {.189f, .168f, .131f + 0.5f, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 0, 0, 1}
                         });

                case cmDramatic:
                    return new ColorMatrix(
                        new[]
                        {
                            new[] {.393f + 0.3f, .349f, .272f, 0, 0},
                            new[] {.769f, .686f + 0.2f, .534f, 0, 0},
                            new[] {.189f, .168f, .131f + 0.9f, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 0, 0, 1}
                        });

                case cmKakao:
                    return new ColorMatrix(
                        new[]
                        {
                            new[] {.393f, .349f, .272f + 1.3f, 0, 0},
                            new[] {.769f, .686f + 0.5f, .534f, 0, 0},
                            new[] {.189f + 2.3f, .168f, .131f, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 0, 0, 1}
                        });

                default:
                    MessageBox.Show($@"{SpecificFilter} is not an accepted filter");
                    return new ColorMatrix();
            }
        }

        /// <summary>
        /// Selects the button.
        /// </summary>
        /// <param name="DesiredButton">The desired button.</param>
        /// <param name="IsEnableUndoNeeded"></param>
        private void SelectButton(Button DesiredButton, bool IsEnableUndoNeeded = true)
        {
            if (IsEnableUndoNeeded)
            {
                EnableButton(UndoButton, Color.LightGray.ToString());
            }

            if (mSelectedFilter != null)
            {
                mSelectedFilter.BackColor = Color.LightGray;
            }

            mSelectedFilter = DesiredButton;
            mSelectedFilter.BackColor = Color.DarkCyan;
        }

        #endregion Helper methods

        #region Image operations

        /// <summary>
        /// Opens the image.
        /// </summary>
        private void OpenImage()
        {
            var dialog_result = openFileDialog1.ShowDialog();

            if (dialog_result == DialogResult.OK)
            {
                mFile = Image.FromFile(openFileDialog1.FileName);
                mInvertedBitmap = new Bitmap(mFile.Width, mFile.Height);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = mFile;
                mUndoRedoImages.Add(mFile);
                mSelectedFilters.Add(NoneButton);
                mCurrentImageIndex = 1;
                SaveButton.Enabled = true;
                SaveButton.BackColor = MidnightBlue;
                panel1.Enabled = true;
                tableLayoutPanel3.Enabled = true;
            }
        }

        /// <summary>
        /// Reloads the image so all previous effects removed.
        /// </summary>
        private void Reload()
        {
            mFile = Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = mFile;
        }

        /// <summary>
        /// Saves the image.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void SaveImage()
        {
            var sfd = new SaveFileDialog
            {
                Filter = @"Images|*.png;*.bmp;*.jpg"
            };

            // create a new save file dialog object
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var extension = Path.GetExtension(sfd.FileName);
                ImageFormat format; // you want to store it in by default format
                switch (extension)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;

                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;

                    case ".png":
                        format = ImageFormat.Png;
                        break;

                    default:
                        MessageBox.Show($@"Extension {extension} is an unaccepted exception");
                        format = ImageFormat.Png;
                        break;
                }

                pictureBox1.Image.Save(sfd.FileName, format);
            }
        }

        #endregion Image operations

        #region Actions

        private void GrayButton_Click_1(object Sender, EventArgs E)
        {
            Reload();
            GrayScale();

            SelectButton(GrayButton);
        }

        private void SujiButton_Click_1(object Sender, EventArgs E)
        {
            Reload();
            Suji();

            SelectButton(SujiButton);
        }

        private void DramaticButton_Click(object Sender, EventArgs E)
        {
            Reload();
            Dramatic();

            SelectButton(DramaticButton);
        }

        private void button12_Click(object Sender, EventArgs E)
        {
            Reload();
            Kakao();

            SelectButton(KakaoButton);
        }

        private void SepiaButton_Click_1(object Sender, EventArgs E)
        {
            Reload();
            Sepia();

            SelectButton(SepiaButton);
        }

        private void SpikeButton_Click_1(object Sender, EventArgs E)
        {
            Reload();
            Spike();

            SelectButton(SpikeButton);
        }

        private void OpenButton_Click_1(object Sender, EventArgs E)
        {
            OpenImage();
        }

        private void NoneButton_Click_1(object Sender, EventArgs E)
        {
            greenbar.Value = 0;
            redbar.Value = 0;
            bluebar.Value = 0;
            Reload();

            SelectButton(NoneButton);
        }

        private void ArtisticButton_Click_1(object Sender, EventArgs E)
        {
            Reload();
            Artistic();

            SelectButton(ArtisticButton);
        }

        private void SaveButton_Click(object Sender, EventArgs E)
        {
            SaveImage();
        }

        private void FlashButton_Click(object Sender, EventArgs E)
        {
            Reload();
            Flash();

            SelectButton(FlashButton);
        }

        private void FrozenButton_Click(object Sender, EventArgs E)
        {
            Reload();
            Frozen();

            SelectButton(FrozenButton);
        }

        private void FiltersExpander_Click_1(object Sender, EventArgs E)
        {
            foreach (Control button in panel1.Controls)
            {
                if (!mExcludedButtons.Contains(button.Text))
                {
                    button.Visible = !button.Visible;
                }
            }
        }

        private void pictureBox1_DoubleClick(object Sender, EventArgs E)
        {
            pictureBox1.SizeMode = pictureBox1.SizeMode == PictureBoxSizeMode.Zoom
                ? PictureBoxSizeMode.Normal
                : PictureBoxSizeMode.Zoom;
        }

        private void RedoButton_Click(object Sender, EventArgs E)
        {
            EnableButton(UndoButton);
            pictureBox1.Image = mUndoRedoImages[++mCurrentImageIndex];
            SelectButton(mSelectedFilters[mCurrentImageIndex - 1], false);

            if (mCurrentImageIndex + 1 == mUndoRedoImages.Count)
            {
                DisableButton(RedoButton);
            }
        }

        private void UndoButton_Click(object Sender, EventArgs E)
        {
            EnableButton(RedoButton);
            pictureBox1.Image = mUndoRedoImages[--mCurrentImageIndex];
            SelectButton(mSelectedFilters[mCurrentImageIndex + 1], false);

            if (mCurrentImageIndex == 0)
            {
                DisableButton(UndoButton);
            }
        }

        private void Form1_Load(object Sender, EventArgs E)
        {
        }

        private void label3_Click(object Sender, EventArgs E)
        {
        }

        private void openFileDialog1_FileOk(object Sender, CancelEventArgs E)
        {
        }

        private void panel1_Paint(object Sender, PaintEventArgs E)
        {
        }

        private void pictureBox1_DragOver(object Sender, DragEventArgs E)
        {
        }

        private void tableLayoutPanel1_Paint(object Sender, PaintEventArgs E)
        {
        }

        private void timer1_Tick(object Sender, EventArgs E)
        {
        }

        private void trackBar1_ValueChanged(object Sender, EventArgs E)
        {
            Hue();
        }

        private void trackBar2_Scroll(object Sender, EventArgs E)
        {
        }

        private void trackBar2_ValueChanged(object Sender, EventArgs E)
        {
            Hue();
        }

        private void trackBar3_Scroll_1(object Sender, EventArgs E)
        {
            Hue();
        }

        private void UndoRedoExpander_Click_1(object Sender, EventArgs E)
        {
            RedoButton.Visible = !RedoButton.Visible;
            UndoButton.Visible = !UndoButton.Visible;
        }

        private void HistogramButton_Click(object Sender, EventArgs E)
        {
            var gray_image = new Bitmap(mFile.Width, mFile.Height);

            var local_graphics = Graphics.FromImage(pictureBox1.Image);

            mImageAttributes.SetColorMatrix(GetColorMatrix(cmGray));

            local_graphics.DrawImage(gray_image, new Rectangle(0, 0, mFile.Width, mFile.Height), 0, 0, mFile.Width,
                mFile.Height, GraphicsUnit.Pixel, mImageAttributes);

            Graphics.Dispose();

            var histogram_values = new Dictionary<int, int>();

            for (var i = 0; i < gray_image.Width; i++)
            for (var j = 0; j < gray_image.Height; j++)
            {
                var pixel = gray_image.GetPixel(i, j).ToArgb();
                if (histogram_values.ContainsKey(pixel))
                {
                    histogram_values[pixel]++;
                }
                else
                {
                    histogram_values.Add(pixel, 1);
                }
            }

            DrawHistogram(histogram_values);
        }

        private void ResizeExpander_Click(object Sender, EventArgs E)
        {
            VerticalTextBox.Visible = !VerticalTextBox.Visible;
            HorizontalTextBox.Visible = !HorizontalTextBox.Visible;
            ResizeButton.Visible = !ResizeButton.Visible;
        }

        private void ResizeButton_Click(object Sender, EventArgs E)
        {
            if (string.IsNullOrEmpty(VerticalTextBox.Text) || string.IsNullOrEmpty(HorizontalTextBox.Text))
            {
                MessageBox.Show(@"Please enter a valid value");
            }

            var vertical_value = 0;
            var horizontal_value = 0;

            try
            {
                vertical_value = int.Parse(VerticalTextBox.Text);
                horizontal_value = int.Parse(HorizontalTextBox.Text);
            }
            catch
            {
                MessageBox.Show(@"Please enter a valid value");
            }

            DrawImage(null, horizontal_value, vertical_value);
        }

        #endregion Actions
    }
}