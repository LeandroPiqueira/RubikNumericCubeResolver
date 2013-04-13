using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cuboNumerico.Model;

namespace cuboNumerico
{
    public partial class frmDadoNumerico : Form
    {
        public frmDadoNumerico()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            btnIniciar.Text = "RESOLVENDO";
            btnIniciar.Enabled = false;
            txtPrompt.Clear();

            CuboNumerico cuboInicial = new CuboNumerico(Convert.ToInt32(txt111.Text), Convert.ToInt32(txt112.Text), Convert.ToInt32(txt113.Text),
                                                        Convert.ToInt32(txt121.Text), Convert.ToInt32(txt122.Text), Convert.ToInt32(txt123.Text),
                                                        Convert.ToInt32(txt131.Text), Convert.ToInt32(txt132.Text), Convert.ToInt32(txt133.Text),
                                                        Convert.ToInt32(txt211.Text), Convert.ToInt32(txt212.Text), Convert.ToInt32(txt213.Text),
                                                        Convert.ToInt32(txt221.Text), Convert.ToInt32(txt222.Text), Convert.ToInt32(txt223.Text),
                                                        Convert.ToInt32(txt231.Text), Convert.ToInt32(txt232.Text), Convert.ToInt32(txt233.Text),
                                                        Convert.ToInt32(txt311.Text), Convert.ToInt32(txt312.Text), Convert.ToInt32(txt313.Text),
                                                        Convert.ToInt32(txt321.Text), Convert.ToInt32(txt322.Text), Convert.ToInt32(txt323.Text),
                                                        Convert.ToInt32(txt331.Text), Convert.ToInt32(txt332.Text), Convert.ToInt32(txt333.Text),
                                                        Convert.ToInt32(txt411.Text), Convert.ToInt32(txt412.Text), Convert.ToInt32(txt413.Text),
                                                        Convert.ToInt32(txt421.Text), Convert.ToInt32(txt422.Text), Convert.ToInt32(txt423.Text),
                                                        Convert.ToInt32(txt431.Text), Convert.ToInt32(txt432.Text), Convert.ToInt32(txt433.Text),
                                                        Convert.ToInt32(txt511.Text), Convert.ToInt32(txt512.Text), Convert.ToInt32(txt513.Text),
                                                        Convert.ToInt32(txt521.Text), Convert.ToInt32(txt522.Text), Convert.ToInt32(txt523.Text),
                                                        Convert.ToInt32(txt531.Text), Convert.ToInt32(txt532.Text), Convert.ToInt32(txt533.Text),
                                                        Convert.ToInt32(txt611.Text), Convert.ToInt32(txt612.Text), Convert.ToInt32(txt613.Text),
                                                        Convert.ToInt32(txt621.Text), Convert.ToInt32(txt622.Text), Convert.ToInt32(txt623.Text),
                                                        Convert.ToInt32(txt631.Text), Convert.ToInt32(txt632.Text), Convert.ToInt32(txt633.Text));
            // * * * 
            CuboNumerico cuboObjetivo = new CuboNumerico(1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6);
            // * * * 
            try
            {
                List<No> solucao = null;

                // * * *
                // Selecionando solução
                // * * * 
                if (rdbLargura.Checked)
                {
                    solucao = Buscas.buscaLargura(cuboInicial, cuboObjetivo, true);
                }
                else if (rdbAestrela.Checked)
                {
                    txtMovimentos.Text = txtMovimentos.Equals(String.Empty) ? "25" : txtMovimentos.Text;
                    solucao = Buscas.buscaAEstrela(cuboInicial, cuboObjetivo, true, Convert.ToInt16(txtMovimentos.Text));
                }

                for (int i = 0; i < solucao.Count(); i++)
                {
                    txtPrompt.Text += solucao[i].Estado.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnIniciar.Text = "RESOLVER";
            btnIniciar.Enabled = true;
         
        }

        private void rdbAestrela_CheckedChanged(object sender, EventArgs e)
        {
            txtMovimentos.Enabled = rdbAestrela.Checked;
        }

        private void rdbMoVertHoriz_CheckedChanged(object sender, EventArgs e)
        {
            btnMovEsq.Enabled = btnMovDir.Enabled = rdbMoVertHoriz.Checked;
        }

        private void movimentaCubo(string movimento, int linhaColuna, int direcao)
        {
            CuboNumerico newCubo = null;
            CuboNumerico cubo = new CuboNumerico(Convert.ToInt32(txt111.Text), Convert.ToInt32(txt112.Text), Convert.ToInt32(txt113.Text),
                                                        Convert.ToInt32(txt121.Text), Convert.ToInt32(txt122.Text), Convert.ToInt32(txt123.Text),
                                                        Convert.ToInt32(txt131.Text), Convert.ToInt32(txt132.Text), Convert.ToInt32(txt133.Text),
                                                        Convert.ToInt32(txt211.Text), Convert.ToInt32(txt212.Text), Convert.ToInt32(txt213.Text),
                                                        Convert.ToInt32(txt221.Text), Convert.ToInt32(txt222.Text), Convert.ToInt32(txt223.Text),
                                                        Convert.ToInt32(txt231.Text), Convert.ToInt32(txt232.Text), Convert.ToInt32(txt233.Text),
                                                        Convert.ToInt32(txt311.Text), Convert.ToInt32(txt312.Text), Convert.ToInt32(txt313.Text),
                                                        Convert.ToInt32(txt321.Text), Convert.ToInt32(txt322.Text), Convert.ToInt32(txt323.Text),
                                                        Convert.ToInt32(txt331.Text), Convert.ToInt32(txt332.Text), Convert.ToInt32(txt333.Text),
                                                        Convert.ToInt32(txt411.Text), Convert.ToInt32(txt412.Text), Convert.ToInt32(txt413.Text),
                                                        Convert.ToInt32(txt421.Text), Convert.ToInt32(txt422.Text), Convert.ToInt32(txt423.Text),
                                                        Convert.ToInt32(txt431.Text), Convert.ToInt32(txt432.Text), Convert.ToInt32(txt433.Text),
                                                        Convert.ToInt32(txt511.Text), Convert.ToInt32(txt512.Text), Convert.ToInt32(txt513.Text),
                                                        Convert.ToInt32(txt521.Text), Convert.ToInt32(txt522.Text), Convert.ToInt32(txt523.Text),
                                                        Convert.ToInt32(txt531.Text), Convert.ToInt32(txt532.Text), Convert.ToInt32(txt533.Text),
                                                        Convert.ToInt32(txt611.Text), Convert.ToInt32(txt612.Text), Convert.ToInt32(txt613.Text),
                                                        Convert.ToInt32(txt621.Text), Convert.ToInt32(txt622.Text), Convert.ToInt32(txt623.Text),
                                                        Convert.ToInt32(txt631.Text), Convert.ToInt32(txt632.Text), Convert.ToInt32(txt633.Text));

            if (movimento.Equals("Lateral"))
                newCubo = cubo.movimentoLateral(linhaColuna, direcao);
            else if (movimento.Equals("Vertical"))
                newCubo = cubo.movimentoVertical(linhaColuna, direcao);
            else if (movimento.Equals("Horizontal"))
                newCubo = cubo.movimentoHorizontal(linhaColuna, direcao);

            escreveCubo(newCubo);

        }

        private void escreveCubo(CuboNumerico cubo)
        {
            ArrayList listaFaces = cubo.faces();

            int[,] face1= (int[,])listaFaces[0];
            int[,] face2 = (int[,])listaFaces[1];
            int[,] face3 = (int[,])listaFaces[2];
            int[,] face4 = (int[,])listaFaces[3];
            int[,] face5 = (int[,])listaFaces[4];
            int[,] face6 = (int[,])listaFaces[5];

            // * * * 
            // Face 1
            txt111.Text = Convert.ToString(face1[0,0]);
            txt112.Text = Convert.ToString(face1[0, 1]);
            txt113.Text = Convert.ToString(face1[0, 2]);

            txt121.Text = Convert.ToString(face1[1, 0]);
            txt122.Text = Convert.ToString(face1[1, 1]);
            txt123.Text = Convert.ToString(face1[1, 2]);

            txt131.Text = Convert.ToString(face1[2, 0]);
            txt132.Text = Convert.ToString(face1[2, 1]);
            txt133.Text = Convert.ToString(face1[2, 2]);

            // * * * 
            // Face 2
            txt211.Text = Convert.ToString(face2[0, 0]);
            txt212.Text = Convert.ToString(face2[0, 1]);
            txt213.Text = Convert.ToString(face2[0, 2]);

            txt221.Text = Convert.ToString(face2[1, 0]);
            txt222.Text = Convert.ToString(face2[1, 1]);
            txt223.Text = Convert.ToString(face2[1, 2]);

            txt231.Text = Convert.ToString(face2[2, 0]);
            txt232.Text = Convert.ToString(face2[2, 1]);
            txt233.Text = Convert.ToString(face2[2, 2]);

            // * * * 
            // Face 3
            txt311.Text = Convert.ToString(face3[0, 0]);
            txt312.Text = Convert.ToString(face3[0, 1]);
            txt313.Text = Convert.ToString(face3[0, 2]);

            txt321.Text = Convert.ToString(face3[1, 0]);
            txt322.Text = Convert.ToString(face3[1, 1]);
            txt323.Text = Convert.ToString(face3[1, 2]);

            txt331.Text = Convert.ToString(face3[2, 0]);
            txt332.Text = Convert.ToString(face3[2, 1]);
            txt333.Text = Convert.ToString(face3[2, 2]);

            // * * * 
            // Face 4
            txt411.Text = Convert.ToString(face4[0, 0]);
            txt412.Text = Convert.ToString(face4[0, 1]);
            txt413.Text = Convert.ToString(face4[0, 2]);
        
            txt421.Text = Convert.ToString(face4[1, 0]);
            txt422.Text = Convert.ToString(face4[1, 1]);
            txt423.Text = Convert.ToString(face4[1, 2]);

            txt431.Text = Convert.ToString(face4[2, 0]);
            txt432.Text = Convert.ToString(face4[2, 1]);
            txt433.Text = Convert.ToString(face4[2, 2]);

            // * * * 
            // Face 5
            txt511.Text = Convert.ToString(face5[0, 0]);
            txt512.Text = Convert.ToString(face5[0, 1]);
            txt513.Text = Convert.ToString(face5[0, 2]);

            txt521.Text = Convert.ToString(face5[1, 0]);
            txt522.Text = Convert.ToString(face5[1, 1]);
            txt523.Text = Convert.ToString(face5[1, 2]);

            txt531.Text = Convert.ToString(face5[2, 0]);
            txt532.Text = Convert.ToString(face5[2, 1]);
            txt533.Text = Convert.ToString(face5[2, 2]);

            // * * * 
            // Face 6
            txt611.Text = Convert.ToString(face6[0, 0]);
            txt612.Text = Convert.ToString(face6[0, 1]);
            txt613.Text = Convert.ToString(face6[0, 2]);

            txt621.Text = Convert.ToString(face6[1, 0]);
            txt622.Text = Convert.ToString(face6[1, 1]);
            txt623.Text = Convert.ToString(face6[1, 2]);

            txt631.Text = Convert.ToString(face6[2, 0]);
            txt632.Text = Convert.ToString(face6[2, 1]);
            txt633.Text = Convert.ToString(face6[2, 2]);

        }

        private void btnMovCima_Click(object sender, EventArgs e)
        {
            string movimento = null;
            if (rdbMovLateral.Checked)
                movimento = "Lateral";
            else
                movimento = "Vertical";

            movimentaCubo(movimento, Convert.ToInt16(cboMovLinCol.Text) - 1, 1);
        }

        private void btnMovBaixo_Click(object sender, EventArgs e)
        {
            string movimento = null;
            if (rdbMovLateral.Checked)
                movimento = "Lateral";
            else
                movimento = "Vertical";

            movimentaCubo(movimento, Convert.ToInt16(cboMovLinCol.Text) - 1, -1);
        }

        private void btnMovDir_Click(object sender, EventArgs e)
        {
            movimentaCubo("Horizontal", Convert.ToInt16(cboMovLinCol.Text) - 1, 1);
        }

        private void btnMovEsq_Click(object sender, EventArgs e)
        {
            movimentaCubo("Horizontal", Convert.ToInt16(cboMovLinCol.Text) - 1, -1);
        }
    }
}
