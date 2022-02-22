using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnBoard
{
    class DisplayManager
    {
        public static void RichTextBoxInvoke(RichTextBox richTextBox, string infoText, Color selectionColor)
        {
            try
            {

                if (!richTextBox.IsHandleCreated || richTextBox.IsDisposed)
                    return;

                if (richTextBox.InvokeRequired)
                    richTextBox.Invoke((MethodInvoker)delegate
                    {

                        //richTextBox.Document.SelectionColor = selectionColor;
                        //richTextBox.AppendText("-------------------------------------------" + "\n");
                        richTextBox.ForeColor = selectionColor;
                        richTextBox.AppendText(infoText + "\n");
                        //richTextBox.AppendText("-------------------------------------------" + "\n");

                    });
                else
                {
                    //richTextBox.Document.SelectionColor = selectionColor;
                    //richTextBox.AppendText("-------------------------------------------" + "\n");
                    richTextBox.ForeColor = selectionColor;
                    richTextBox.AppendText(infoText + "\n");
                    //richTextBox.AppendText("-------------------------------------------" + "\n");

                }
            }
            catch
            {
            }
        }

        public static void LabelInvoke(Label label, string text)
        {
            if (label.InvokeRequired)
                label.Invoke((MethodInvoker)delegate
                {
                    label.Text = text;
                });
            else
            {
                label.Text = text;
            }
        }


        //public static int TabControlSelectedIndexInvoke(TabControl tabControl)
        //{
        //    int selectedIndex = 0;

        //    if (tabControl.InvokeRequired)
        //        tabControl.Invoke((MethodInvoker)delegate
        //        {
        //            selectedIndex = tabControl.SelectedIndex;
        //        });
        //    else
        //    {
        //        selectedIndex = tabControl.SelectedIndex;
        //    }

        //    return selectedIndex;
        //}


        public static void LabelInvokeWithColor(Label label, string text)
        {
            if (label.InvokeRequired)
                label.Invoke((MethodInvoker)delegate
                {
                    int.TryParse(text, out int counter);

                    if (counter < 6)
                        label.ForeColor = Color.Red;
                    else
                        label.ForeColor = Color.Black;


                    label.Text = text;
                });
            else
            {

                int.TryParse(text, out int counter);

                if (counter < 6)
                    label.ForeColor = Color.Red;
                else
                    label.ForeColor = Color.Black;

                label.Text = text;
            }
        }

        public static void TextBoxInvoke(TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)
                textBox.Invoke((MethodInvoker)delegate
                {
                    textBox.Text = text;
                });
            else
            {
                textBox.Text = text;
            }
        }

        public static void TextBoxClearInvoke(TextBox textBox)
        {
            if (textBox.InvokeRequired)
                textBox.Invoke((MethodInvoker)delegate
                {
                    textBox.Clear();
                });
            else
            {
                textBox.Clear();
            }
        }


        public static void ListViewInvoke(ListView listView, string text)
        {
            if (listView.InvokeRequired)
                listView.Invoke((MethodInvoker)delegate
                {
                    //label.Text = text;
                });
            else
            {
                //label.Text = text;
            }
        }


        public static void ListViewItemsClearInvoke(ListView listView)
        {
            //lock (listView)
            {
                if (listView.InvokeRequired)
                    listView.Invoke((MethodInvoker)delegate
                    {
                        listView.Items.Clear();
                    });
                else
                {
                    listView.Items.Clear();
                }
            }
        }

        public static void ListViewItemsAddInvoke(ListView listView, ListViewItem listViewItem)
        {

            //lock (listView)
            {
                if (listView.InvokeRequired)
                    listView.Invoke((MethodInvoker)delegate
                    {
                        listView.Items.Add(listViewItem);
                    });
                else
                {
                    listView.Items.Add(listViewItem);
                }
            }
        }


        public static void ListViewItemBackColorInvoke(ListView listView, int itemIndex, Color backColor)
        {
            if (listView.InvokeRequired)
                listView.Invoke((MethodInvoker)delegate
                {
                    listView.Items[itemIndex].BackColor = backColor;
                });
            else
            {
                listView.Items[itemIndex].BackColor = backColor;
            }
        }

        //public static void ListViewItemBackColorInvoke(ListView listView)
        //{
        //    if (listView.InvokeRequired)
        //        listView.Invoke((MethodInvoker)delegate
        //        {
        //              //trenin tracklerini kırmızıya boyama
        //             foreach (ListViewItem li in listView.Items)
        //            {
        //                int itemText = Convert.ToInt32(li.Text);

        //                Track lolo = UIOBATP.TrainOnTracks.ActualLocationTracks.Find(x => x.Track_ID == itemText);

        //                if (lolo != null)
        //                {
        //                    //li.ForeColor = Color.Red;
        //                    li.BackColor = Color.Red;
        //                }
        //                else
        //                {
        //                    li.BackColor = Color.White;
        //                }
        //            }
        //        });
        //    else
        //    {
        //        //trenin tracklerini kırmızıya boyama
        //        foreach (ListViewItem li in m_listView.Items)
        //        {
        //            int itemText = Convert.ToInt32(li.Text);

        //            Track lolo = UIOBATP.TrainOnTracks.ActualLocationTracks.Find(x => x.Track_ID == itemText);

        //            if (lolo != null)
        //            {
        //                //li.ForeColor = Color.Red;
        //                li.BackColor = Color.Red;
        //            }
        //            else
        //            {
        //                li.BackColor = Color.White;
        //            }
        //        }
        //    }
        //}

















        public static object ComboBoxGetSelectedItemInvoke(ComboBox combobox)
        {
            //lock(combobox)
            {
                object selectedItem = null;

                MethodInvoker miClearItems = delegate
                {
                    selectedItem = combobox.SelectedItem;
                };

                if (combobox.InvokeRequired)
                {
                    combobox.Invoke(miClearItems);
                }
                else
                {
                    miClearItems();
                }

                return selectedItem;
            }
          
        }

        public static void ComboBoxInvoke(ComboBox comboBox, string text)
        {
            if (comboBox.InvokeRequired)
                comboBox.Invoke((MethodInvoker)delegate
                {
                    //label.Text = text;
                });
            else
            {
                //label.Text = text;
            }
        }


        public static void PanelInvoke(Panel panel, Color backColor)
        {
            if (panel.InvokeRequired)
                panel.Invoke((MethodInvoker)delegate
                {
                    panel.BackColor = backColor;
                });
            else
            {
                panel.BackColor = backColor;
            }
        }


        public static void PictureBoxInvoke(PictureBox pictureBox, Bitmap bitmap)
        {
            if (pictureBox.InvokeRequired)
                pictureBox.Invoke((MethodInvoker)delegate
                {
                    pictureBox.Image = bitmap;
                });
            else
            {
                pictureBox.Image = bitmap;
            }
        }
    }
}
