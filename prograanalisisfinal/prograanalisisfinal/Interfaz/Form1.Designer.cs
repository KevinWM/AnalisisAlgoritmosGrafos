namespace PrograAnalisisFinal
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.BTNrutaAlgoritmoGenetico = new System.Windows.Forms.Button();
            this.BTNalgoritmoProbabilistico = new System.Windows.Forms.Button();
            this.origentextBox = new System.Windows.Forms.TextBox();
            this.destinotextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cantidaExploradorastextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nuevaDistanciatextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(27, 111);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(247, 188);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // BTNrutaAlgoritmoGenetico
            // 
            this.BTNrutaAlgoritmoGenetico.Location = new System.Drawing.Point(27, 337);
            this.BTNrutaAlgoritmoGenetico.Name = "BTNrutaAlgoritmoGenetico";
            this.BTNrutaAlgoritmoGenetico.Size = new System.Drawing.Size(247, 41);
            this.BTNrutaAlgoritmoGenetico.TabIndex = 1;
            this.BTNrutaAlgoritmoGenetico.Text = "Ruta Algoritmo Genetico";
            this.BTNrutaAlgoritmoGenetico.UseVisualStyleBackColor = true;
            this.BTNrutaAlgoritmoGenetico.Click += new System.EventHandler(this.BTNrutaAlgoritmoGenetico_Click);
            // 
            // BTNalgoritmoProbabilistico
            // 
            this.BTNalgoritmoProbabilistico.Location = new System.Drawing.Point(27, 413);
            this.BTNalgoritmoProbabilistico.Name = "BTNalgoritmoProbabilistico";
            this.BTNalgoritmoProbabilistico.Size = new System.Drawing.Size(247, 36);
            this.BTNalgoritmoProbabilistico.TabIndex = 2;
            this.BTNalgoritmoProbabilistico.Text = "Ruta Algoritmo Probabilistiico";
            this.BTNalgoritmoProbabilistico.UseVisualStyleBackColor = true;
            this.BTNalgoritmoProbabilistico.Click += new System.EventHandler(this.BTNalgoritmoProbabilistico_Click);
            // 
            // origentextBox
            // 
            this.origentextBox.Location = new System.Drawing.Point(150, 12);
            this.origentextBox.Name = "origentextBox";
            this.origentextBox.Size = new System.Drawing.Size(100, 20);
            this.origentextBox.TabIndex = 3;
            // 
            // destinotextBox
            // 
            this.destinotextBox.Location = new System.Drawing.Point(150, 38);
            this.destinotextBox.Name = "destinotextBox";
            this.destinotextBox.Size = new System.Drawing.Size(100, 20);
            this.destinotextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Origen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Destino:";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(316, 111);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(247, 188);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cantidad Exploradoras:";
            // 
            // cantidaExploradorastextBox
            // 
            this.cantidaExploradorastextBox.Location = new System.Drawing.Point(150, 66);
            this.cantidaExploradorastextBox.Name = "cantidaExploradorastextBox";
            this.cantidaExploradorastextBox.Size = new System.Drawing.Size(100, 20);
            this.cantidaExploradorastextBox.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cambiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Nueva Distancia:";
            // 
            // nuevaDistanciatextBox
            // 
            this.nuevaDistanciatextBox.Location = new System.Drawing.Point(365, 12);
            this.nuevaDistanciatextBox.Name = "nuevaDistanciatextBox";
            this.nuevaDistanciatextBox.Size = new System.Drawing.Size(100, 20);
            this.nuevaDistanciatextBox.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 480);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nuevaDistanciatextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cantidaExploradorastextBox);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.destinotextBox);
            this.Controls.Add(this.origentextBox);
            this.Controls.Add(this.BTNalgoritmoProbabilistico);
            this.Controls.Add(this.BTNrutaAlgoritmoGenetico);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button BTNrutaAlgoritmoGenetico;
        private System.Windows.Forms.Button BTNalgoritmoProbabilistico;
        private System.Windows.Forms.TextBox origentextBox;
        private System.Windows.Forms.TextBox destinotextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cantidaExploradorastextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nuevaDistanciatextBox;
    }
}

