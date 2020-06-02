using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulacionDados
{
    public partial class Simulacion : Form
    {
        public Simulacion()
        {
            InitializeComponent();
        }
        int total = 0;
        int contador = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            else
            {
                MyerrorProvider.Clear();
                contador++;
                lanzadoLabel.Text = contador.ToString();
                LanzarDados();
            }
        }

        private bool Validar() //Funcion que valida La Probabilidad no este vacia
        {
            bool paso = true;

            if (numericUpDown1.Value == 0) 
            {
                numericUpDown1.Focus();
                MyerrorProvider.SetError(numericUpDown1, "Debe agregar la probabilidad para el #1");
                paso = false;
            }
            if (numericUpDown2.Value == 0)
            {
                numericUpDown2.Focus();
                MyerrorProvider.SetError(numericUpDown2, "Debe agregar la probabilidad para el #2");

                paso = false;
            }
            if (numericUpDown3.Value == 0)
            {
                numericUpDown3.Focus();
                MyerrorProvider.SetError(numericUpDown3, "Debe agregar la probabilidad para el #3");

                paso = false;
            }
            if (numericUpDown4.Value == 0) 
            {
                numericUpDown4.Focus();
                MyerrorProvider.SetError(numericUpDown4, "Debe agregar la probabilidad para el #4");

                paso = false;
            }
            if (numericUpDown5.Value == 0) 
            {
                numericUpDown5.Focus();
                MyerrorProvider.SetError(numericUpDown5, "Debe agregar la probabilidad para el #5");

                paso = false;
            }
            if (numericUpDown6.Value == 0) 
            {
                numericUpDown6.Focus();
                MyerrorProvider.SetError(numericUpDown6, "Debe agregar la probabilidad para el #6");
                paso = false;
            }

            return paso;
        }



            public void LanzarDados()
        {
            decimal total = 100, num;
            decimal[] dado = new decimal[6];
            int t;

            Random rand = new Random();


            for (int x = 0; x <= 5; x++)
            {
                if (x == 0)
                {
                    dado[x] = Convert.ToDecimal(numericUpDown1.Text);
                }
                else if (x == 1)
                {
                    dado[x] = Convert.ToDecimal(numericUpDown2.Text);
                }
                else if (x == 2)
                {
                    dado[x] = Convert.ToDecimal(numericUpDown3.Text);
                }
                else if (x == 3)
                {
                    dado[x] = Convert.ToDecimal(numericUpDown4.Text);
                }
                else if (x == 4)
                {
                    dado[x] = Convert.ToDecimal(numericUpDown5.Text);
                }
                else if (x == 5)
                {
                    dado[x] = Convert.ToDecimal(numericUpDown6.Text);
                }

                total -= dado[x];
                dado[x] = dado[x] / 100; 
            }

            num = rand.Next(1, 7);

            for (int x = 1; x <= 1; x++)
            {
                num = num / 6;

                if (dado[0] >= num)
                {
                    imagenDado.Image = SimulacionDados.Properties.Resources._1;     
                }

                if (dado[1] >= num && num > dado[0])
                {
                    imagenDado.Image = SimulacionDados.Properties.Resources._2;
                }

                if (dado[2] >= num && num > dado[1])
                {
                    imagenDado.Image = SimulacionDados.Properties.Resources._3;
                }
                if (dado[3] >= num && num > dado[2])
                {
                    imagenDado.Image = SimulacionDados.Properties.Resources._4;
                }
                if (dado[4] >= num && num > dado[3])
                {
                    imagenDado.Image = SimulacionDados.Properties.Resources._5;
                }
                if (dado[5] >= num && num > dado[4])
                {
                    imagenDado.Image = SimulacionDados.Properties.Resources._6;    
                }
            }
        }

        public void dado()
        {
            Random rand = new Random();
            double num;

            num = rand.Next(1, 7);

            for (int x = 1; x <= 1; x++)
            {
                num = num / 100;

                if (num == 0.01)
                {
                    imagenDado2.Image = SimulacionDados.Properties.Resources._1;
                }

                if (num == 0.02)
                {
                    imagenDado2.Image = SimulacionDados.Properties.Resources._2;
                }

                if (num == 0.03)
                {
                    imagenDado2.Image = SimulacionDados.Properties.Resources._3;
                }
                if (num == 0.04)
                {
                    imagenDado2.Image = SimulacionDados.Properties.Resources._4;
                }
                if (num == 0.05)
                {
                    imagenDado2.Image = SimulacionDados.Properties.Resources._5;
                }
                if (num >= 0.06)
                {
                    imagenDado2.Image = SimulacionDados.Properties.Resources._6;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dado();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imagenDado2.Image = SimulacionDados.Properties.Resources.dado_imagen_animada_0064;
        }

        

        public void SumarPorciento()
        {
             total = Convert.ToInt32(numericUpDown1.Text) +
                     Convert.ToInt32(numericUpDown2.Text) +
                     Convert.ToInt32(numericUpDown3.Text) +
                     Convert.ToInt32(numericUpDown4.Text) +
                     Convert.ToInt32(numericUpDown5.Text) +
                     Convert.ToInt32(numericUpDown6.Text);
                     total =  100-total;
                    totalLabel.Text =  total.ToString()+"%";
        
            if (total < 0)
            {
                //MyerrorProvider.SetError(numericUpDown1, "Error, El Porcentaje no puede ser Mayor a 100%");
               MessageBox.Show("Error, El Porcentaje no puede ser Mayor a 100%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void numericUpDown2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (numericUpDown2.Text == "")
                    numericUpDown2.Value = 0;
                else
                    SumarPorciento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (numericUpDown1.Text == "")
                    numericUpDown1.Value = 0;
                else
                    SumarPorciento();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown3_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (numericUpDown3.Text == "")
                    numericUpDown3.Value = 0;
                else
                    SumarPorciento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown4_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (numericUpDown4.Text == "")
                    numericUpDown4.Value = 0;
                else
                    SumarPorciento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown5_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (numericUpDown5.Text == "")
                    numericUpDown5.Value = 0;
                else
                    SumarPorciento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown6_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (numericUpDown6.Text == "" || numericUpDown6.Text == 0.ToString())
                    numericUpDown6.Value = 0;
                else
                    SumarPorciento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown6_Leave(object sender, EventArgs e)
        {
            if (numericUpDown6.Text == "")
                numericUpDown6.Text = "0";
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            if (numericUpDown1.Text == "")
                numericUpDown1.Text = "0";
        }

        private void numericUpDown2_Leave(object sender, EventArgs e)
        {
            if (numericUpDown2.Text == "")
                numericUpDown2.Text = "0";
        }

        private void numericUpDown3_Leave(object sender, EventArgs e)
        {
            if (numericUpDown3.Text == "")
                numericUpDown3.Text = "0";
        }

        private void numericUpDown4_Leave(object sender, EventArgs e)
        {
            if (numericUpDown4.Text == "")
                numericUpDown4.Text = "0";
        }

        private void numericUpDown5_Leave(object sender, EventArgs e)
        {
            if (numericUpDown5.Text == "")
                numericUpDown5.Text = "0";
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown6.Text == "")
                numericUpDown6.Value = 0;
        }

        private void numericUpDown6_Enter(object sender, EventArgs e)
        {
            if (numericUpDown6.Value == 0)
                numericUpDown6.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            imagenDado.Image = SimulacionDados.Properties.Resources.dado_imagen_animada_0016;
            numericUpDown1.Value = 0; numericUpDown2.Value = 0;
            numericUpDown3.Value = 0; numericUpDown4.Value = 0;
            numericUpDown5.Value = 0; numericUpDown6.Value = 0;
            total = 0;
            contador = 0;
            totalLabel.Text = "100 %";
            MyerrorProvider.Clear();
        }


        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
                numericUpDown1.Text = "";
        }

        private void numericUpDown2_Enter(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 0)
                numericUpDown2.Text = "";
        }

        private void numericUpDown3_Enter(object sender, EventArgs e)
        {
            if (numericUpDown3.Value == 0)
                numericUpDown3.Text = "";
        }

        private void numericUpDown4_Enter(object sender, EventArgs e)
        {
            if (numericUpDown4.Value == 0)
                numericUpDown4.Text = "";
        }

        private void numericUpDown5_Enter(object sender, EventArgs e)
        {
            if (numericUpDown5.Value == 0)
                numericUpDown5.Text = "";
        }

       
    }
}
