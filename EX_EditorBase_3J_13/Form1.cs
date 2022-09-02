using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EX_EditorBase_3J_13
{
    public partial class Form1 : Form
    {

        StreamReader leitura = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exibirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovoArquivo();
        }

        private void NovoArquivo()
        {
            rtbText.Clear();
            rtbText.Focus();
        }

        private void Novo_Click(object sender, EventArgs e)
        {
            NovoArquivo();
        }

        private void Abrir_Click(object sender, EventArgs e)
        {
            abrirArquivo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirArquivo();
        }

        private void abrirArquivo()
        {
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\logon\Documents";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "*.TXT|*txt|Todos Arquivos (*.*)|*.*";

            try
            {
                if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(arquivo);
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.rtbText.Text = "";
                    string linha = sr.ReadLine();
                    while(linha != null)
                    {
                        this.rtbText.Text += linha + "\n";
                        linha = sr.ReadLine();
                    }
                    sr.Close();
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Erro Ao Abrir: " + ex.Message, "giustt's Notepad Says", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvarArquivo();
        }

        private void salvarArquivo()
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(arquivo);
                    sw.Flush();
                    sw.BaseStream.Seek(0, SeekOrigin.Begin);
                    sw.Write(this.rtbText.Text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao Salvar: " + ex.Message, "Notepad By Giustt Informa:",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            salvarArquivo();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copiarTexto();
        }

        private void copiarTexto()
        {
            if(rtbText.SelectionLength > 0)
            {
                rtbText.Copy();
            }
        }

        private void Copiar_Click(object sender, EventArgs e)
        {
            copiarTexto();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colarTexto();
        }

        private void colarTexto()
        {
            rtbText.Paste();
        }

        private void Colar_Click(object sender, EventArgs e)
        {
            colarTexto();
        }


        private void boldText()
        {
            string nomeFonte = rtbText.SelectionFont.Name;
            float tamanhoFonte = rtbText.SelectionFont.Size;
            bool resp;
            resp = rtbText.SelectionFont.Bold;

            if (resp == false)
            {
                rtbText.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold);
            }
            else
            {
                rtbText.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Regular);
            }
        }


        private void italicText()
        {
            string nomeFonte = rtbText.SelectionFont.Name;
            float tamanhoFonte = rtbText.SelectionFont.Size;
            bool resp;
            resp = rtbText.SelectionFont.Italic;

            if (resp == false)
            {
                rtbText.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Italic);
            }
            else
            {
                rtbText.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Regular);
            }
        }

        private void underlineText()
        {
            string nomeFonte = rtbText.SelectionFont.Name;
            float tamanhoFonte = rtbText.SelectionFont.Size;
            bool resp;
            resp = rtbText.SelectionFont.Underline;

            if (resp == false)
            {
                rtbText.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Underline);
            }
            else
            {
                rtbText.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Regular);
            }
        }


        private void Negrito_Click(object sender, EventArgs e)
        {
            boldText();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boldText();
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            italicText();
        }

        private void Italic_Click(object sender, EventArgs e)
        {
            italicText();
        }

        private void Sublinhado_Click(object sender, EventArgs e)
        {
            underlineText();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            underlineText();
        }

        private void Fonte_Click_1(object sender, EventArgs e)
        {
            FontDialog fonte = new FontDialog();
            if (fonte.ShowDialog() == DialogResult.OK)
            {
                rtbText.Font = fonte.Font;
            }
        }

        private void Esquerda_Click(object sender, EventArgs e)
        {
            alignLeft();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignLeft();
        }

        private void alignLeft()
        {
            rtbText.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignRight();
        }

        private void Direita_Click(object sender, EventArgs e)
        {
            alignRight();
        }

        private void alignRight()
        {
            rtbText.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void Centralizar_Click(object sender, EventArgs e)
        {
            alignCenter();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignCenter();
        }

        private void alignCenter()
        {
            rtbText.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitApp();
        }

        static void exitApp()
        {
            /* MessageBox.Show("Deseja Salvar o Arquivo Antes de Sair? ", "Deseja Realmente Sair de Notepad By Giustt", MessageBoxButtons.YesNo);
            Environment.Exit(0);
            rtbText.Undo();
            rtbText.Redo();
            */

            if (MessageBox.Show("Deseja Realmente Sair de Notepad By Giustt?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Environment.Exit(0);
            }

        }
    }
}
