using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Мили", "Километры", "Футы", "Метры", "Дюймы", "Сантиметры" });
            comboBox2.Items.AddRange(new string[] { "Мили", "Километры", "Футы", "Метры", "Дюймы", "Сантиметры" });

           // cmbFromUnit.SelectedIndex = 0; // Значение по умолчанию
            //cmbToUnit.SelectedIndex = 1;
        }
        private double ConvertUnits(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit)
                return value;

            // Конвертация длины
            if (fromUnit == "Мили" && toUnit == "Километры") return value * 1.60934;
            if (fromUnit == "Километры" && toUnit == "Мили") return value / 1.60934;
            if (fromUnit == "Футы" && toUnit == "Метры") return value * 0.3048;
            if (fromUnit == "Метры" && toUnit == "Футы") return value / 0.3048;
            if (fromUnit == "Дюймы" && toUnit == "Сантиметры") return value * 2.54;
            if (fromUnit == "Сантиметры" && toUnit == "Дюймы") return value / 2.54;

            throw new Exception("Конвертация между выбранными единицами не поддерживается.");
        }
        private void btnLoadFile_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, textOutput.Text);
                    MessageBox.Show("Результат сохранён успешно.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения файла: {ex.Message}");
                }
            }
        }

        private void btnSaveFile_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, textOutput.Text);
            }
        }

        private void btnConvert_Click_1(object sender, EventArgs e)
        {
            try
            {
                double inputValue = double.Parse(txtInput.Text);
                string fromUnit = comboBox1.SelectedItem.ToString();
                string toUnit = comboBox2.SelectedItem.ToString();

                double result = ConvertUnits(inputValue, fromUnit, toUnit);
                textOutput.Text = result.ToString("F2"); // Результат с 2 знаками после запятой
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректное числовое значение.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
