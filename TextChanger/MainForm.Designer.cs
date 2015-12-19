using System.Drawing;

namespace TextChanger {
    partial class MainForm {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelSourceText = new System.Windows.Forms.Label();
            this.labelNewText = new System.Windows.Forms.Label();
            this.btnLineReverse = new System.Windows.Forms.Button();
            this.btnToLower = new System.Windows.Forms.Button();
            this.btnToUpper = new System.Windows.Forms.Button();
            this.sourceText = new System.Windows.Forms.TextBox();
            this.newText = new System.Windows.Forms.TextBox();
            this.btnWordsWithUpper = new System.Windows.Forms.Button();
            this.btnWithoutSpaces = new System.Windows.Forms.Button();
            this.btnWithoutPunctuation = new System.Windows.Forms.Button();
            this.btnReplaceTexts = new System.Windows.Forms.Button();
            this.btnChangeLayout = new System.Windows.Forms.Button();
            this.btnWithoutVowels = new System.Windows.Forms.Button();
            this.btnWithoutConsonants = new System.Windows.Forms.Button();
            this.btnSpacesAfterChar = new System.Windows.Forms.Button();
            this.checkBoxAutoReplace = new System.Windows.Forms.CheckBox();
            this.btnInSyllables = new System.Windows.Forms.Button();
            this.btnTransliteration = new System.Windows.Forms.Button();
            this.btnWordLine = new System.Windows.Forms.Button();
            this.btnCharLine = new System.Windows.Forms.Button();
            this.btnWithoutSuperfluousSpaces = new System.Windows.Forms.Button();
            this.btnWithoutParagraph = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSourceText
            // 
            this.labelSourceText.AutoSize = true;
            this.labelSourceText.Location = new System.Drawing.Point(10, 9);
            this.labelSourceText.Name = "labelSourceText";
            this.labelSourceText.Size = new System.Drawing.Size(89, 13);
            this.labelSourceText.TabIndex = 0;
            this.labelSourceText.Text = "Исходный текст";
            // 
            // labelNewText
            // 
            this.labelNewText.Location = new System.Drawing.Point(316, 9);
            this.labelNewText.Name = "labelNewText";
            this.labelNewText.Size = new System.Drawing.Size(72, 15);
            this.labelNewText.TabIndex = 1;
            this.labelNewText.Text = "Новый текст";
            // 
            // btnLineReverse
            // 
            this.btnLineReverse.Location = new System.Drawing.Point(625, 12);
            this.btnLineReverse.Name = "btnLineReverse";
            this.btnLineReverse.Size = new System.Drawing.Size(85, 50);
            this.btnLineReverse.TabIndex = 4;
            this.btnLineReverse.Text = "Строки наоборот";
            this.btnLineReverse.UseVisualStyleBackColor = true;
            this.btnLineReverse.Click += new System.EventHandler(this.btnLineReverse_Click);
            // 
            // btnToLower
            // 
            this.btnToLower.Location = new System.Drawing.Point(625, 63);
            this.btnToLower.Name = "btnToLower";
            this.btnToLower.Size = new System.Drawing.Size(85, 50);
            this.btnToLower.TabIndex = 6;
            this.btnToLower.Text = "Строчные буквы";
            this.btnToLower.UseVisualStyleBackColor = true;
            this.btnToLower.Click += new System.EventHandler(this.btnToLower_Click);
            // 
            // btnToUpper
            // 
            this.btnToUpper.Location = new System.Drawing.Point(711, 63);
            this.btnToUpper.Name = "btnToUpper";
            this.btnToUpper.Size = new System.Drawing.Size(85, 50);
            this.btnToUpper.TabIndex = 7;
            this.btnToUpper.Text = "Прописные буквы";
            this.btnToUpper.UseVisualStyleBackColor = true;
            this.btnToUpper.Click += new System.EventHandler(this.btnToUpper_Click);
            // 
            // textBoxSource
            // 
            this.sourceText.Location = new System.Drawing.Point(13, 25);
            this.sourceText.Multiline = true;
            this.sourceText.Name = "textBoxSource";
            this.sourceText.Size = new System.Drawing.Size(300, 450);
            this.sourceText.TabIndex = 2;
            // 
            // textBoxNew
            // 
            this.newText.Location = new System.Drawing.Point(320, 25);
            this.newText.Multiline = true;
            this.newText.Name = "textBoxNew";
            this.newText.Size = new System.Drawing.Size(300, 450);
            this.newText.TabIndex = 3;
            // 
            // btnWordsWithUpper
            // 
            this.btnWordsWithUpper.Location = new System.Drawing.Point(711, 12);
            this.btnWordsWithUpper.Name = "btnWordsWithUpper";
            this.btnWordsWithUpper.Size = new System.Drawing.Size(85, 50);
            this.btnWordsWithUpper.TabIndex = 5;
            this.btnWordsWithUpper.Text = "Слова с прописной буквы";
            this.btnWordsWithUpper.UseVisualStyleBackColor = true;
            this.btnWordsWithUpper.Click += new System.EventHandler(this.btnWordsWithUpper_Click);
            // 
            // btnWithoutSpaces
            // 
            this.btnWithoutSpaces.Location = new System.Drawing.Point(625, 165);
            this.btnWithoutSpaces.Name = "btnWithoutSpaces";
            this.btnWithoutSpaces.Size = new System.Drawing.Size(85, 50);
            this.btnWithoutSpaces.TabIndex = 10;
            this.btnWithoutSpaces.Text = "Без пробелов";
            this.btnWithoutSpaces.UseVisualStyleBackColor = true;
            this.btnWithoutSpaces.Click += new System.EventHandler(this.btnWithoutSpaces_Click);
            // 
            // btnWithoutPunctuation
            // 
            this.btnWithoutPunctuation.Location = new System.Drawing.Point(711, 267);
            this.btnWithoutPunctuation.Name = "btnWithoutPunctuation";
            this.btnWithoutPunctuation.Size = new System.Drawing.Size(85, 50);
            this.btnWithoutPunctuation.TabIndex = 15;
            this.btnWithoutPunctuation.Text = "Без пунктуации";
            this.btnWithoutPunctuation.UseVisualStyleBackColor = true;
            this.btnWithoutPunctuation.Click += new System.EventHandler(this.btnWithoutPunctuation_Click);
            // 
            // btnReplaceTexts
            // 
            this.btnReplaceTexts.Location = new System.Drawing.Point(625, 435);
            this.btnReplaceTexts.Name = "btnReplaceTexts";
            this.btnReplaceTexts.Size = new System.Drawing.Size(85, 40);
            this.btnReplaceTexts.TabIndex = 20;
            this.btnReplaceTexts.Text = "Заменить текст";
            this.btnReplaceTexts.UseVisualStyleBackColor = true;
            this.btnReplaceTexts.Click += new System.EventHandler(this.btnReplaceTexts_Click);
            // 
            // btnChangeLayout
            // 
            this.btnChangeLayout.Location = new System.Drawing.Point(625, 114);
            this.btnChangeLayout.Name = "btnChangeLayout";
            this.btnChangeLayout.Size = new System.Drawing.Size(85, 50);
            this.btnChangeLayout.TabIndex = 8;
            this.btnChangeLayout.Text = "Смена раскладки";
            this.btnChangeLayout.UseVisualStyleBackColor = true;
            this.btnChangeLayout.Click += new System.EventHandler(this.btnChangeLayout_Click);
            // 
            // btnWithoutVowels
            // 
            this.btnWithoutVowels.Location = new System.Drawing.Point(711, 216);
            this.btnWithoutVowels.Name = "btnWithoutVowels";
            this.btnWithoutVowels.Size = new System.Drawing.Size(85, 50);
            this.btnWithoutVowels.TabIndex = 13;
            this.btnWithoutVowels.Text = "Без гласных";
            this.btnWithoutVowels.UseVisualStyleBackColor = true;
            this.btnWithoutVowels.Click += new System.EventHandler(this.btnWithoutVowels_Click);
            // 
            // btnWithoutConsonants
            // 
            this.btnWithoutConsonants.Location = new System.Drawing.Point(625, 216);
            this.btnWithoutConsonants.Name = "btnWithoutConsonants";
            this.btnWithoutConsonants.Size = new System.Drawing.Size(85, 50);
            this.btnWithoutConsonants.TabIndex = 12;
            this.btnWithoutConsonants.Text = "Без согласных";
            this.btnWithoutConsonants.UseVisualStyleBackColor = true;
            this.btnWithoutConsonants.Click += new System.EventHandler(this.btnWithoutConsonants_Click);
            // 
            // btnSpacesAfterChar
            // 
            this.btnSpacesAfterChar.Location = new System.Drawing.Point(711, 165);
            this.btnSpacesAfterChar.Name = "btnSpacesAfterChar";
            this.btnSpacesAfterChar.Size = new System.Drawing.Size(85, 50);
            this.btnSpacesAfterChar.TabIndex = 11;
            this.btnSpacesAfterChar.Text = "Пробелы через символ";
            this.btnSpacesAfterChar.UseVisualStyleBackColor = true;
            this.btnSpacesAfterChar.Click += new System.EventHandler(this.btnWithSpacesAfterSChar_Click);
            // 
            // checkBoxAutoReplace
            // 
            this.checkBoxAutoReplace.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxAutoReplace.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxAutoReplace.Location = new System.Drawing.Point(711, 435);
            this.checkBoxAutoReplace.Name = "checkBoxAutoReplace";
            this.checkBoxAutoReplace.Size = new System.Drawing.Size(85, 40);
            this.checkBoxAutoReplace.TabIndex = 21;
            this.checkBoxAutoReplace.Text = "Автозамена";
            this.checkBoxAutoReplace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxAutoReplace.UseVisualStyleBackColor = true;
            this.checkBoxAutoReplace.CheckedChanged += new System.EventHandler(this.checkBoxAutoReplace_CheckedChanged);
            // 
            // btnInSyllables
            // 
            this.btnInSyllables.Location = new System.Drawing.Point(625, 267);
            this.btnInSyllables.Name = "btnInSyllables";
            this.btnInSyllables.Size = new System.Drawing.Size(85, 50);
            this.btnInSyllables.TabIndex = 14;
            this.btnInSyllables.Text = "По слогам";
            this.btnInSyllables.UseVisualStyleBackColor = true;
            this.btnInSyllables.Click += new System.EventHandler(this.btnInSyllables_Click);
            // 
            // btnTransliteration
            // 
            this.btnTransliteration.Location = new System.Drawing.Point(711, 114);
            this.btnTransliteration.Name = "btnTransliteration";
            this.btnTransliteration.Size = new System.Drawing.Size(85, 50);
            this.btnTransliteration.TabIndex = 9;
            this.btnTransliteration.Text = "Транслит";
            this.btnTransliteration.UseVisualStyleBackColor = true;
            this.btnTransliteration.Click += new System.EventHandler(this.btnTransliteration_Click);
            // 
            // btnWordLine
            // 
            this.btnWordLine.Location = new System.Drawing.Point(625, 318);
            this.btnWordLine.Name = "btnWordLine";
            this.btnWordLine.Size = new System.Drawing.Size(85, 50);
            this.btnWordLine.TabIndex = 16;
            this.btnWordLine.Text = "Слово-строка";
            this.btnWordLine.UseVisualStyleBackColor = true;
            this.btnWordLine.Click += new System.EventHandler(this.btnWordLine_Click);
            // 
            // btnCharLine
            // 
            this.btnCharLine.Location = new System.Drawing.Point(711, 318);
            this.btnCharLine.Name = "btnCharLine";
            this.btnCharLine.Size = new System.Drawing.Size(85, 50);
            this.btnCharLine.TabIndex = 17;
            this.btnCharLine.Text = "Символ- строка";
            this.btnCharLine.UseVisualStyleBackColor = true;
            this.btnCharLine.Click += new System.EventHandler(this.btnCharLine_Click);
            // 
            // btnWithoutSuperfluousSpaces
            // 
            this.btnWithoutSuperfluousSpaces.Location = new System.Drawing.Point(626, 369);
            this.btnWithoutSuperfluousSpaces.Name = "btnWithoutSuperfluousSpaces";
            this.btnWithoutSuperfluousSpaces.Size = new System.Drawing.Size(85, 50);
            this.btnWithoutSuperfluousSpaces.TabIndex = 18;
            this.btnWithoutSuperfluousSpaces.Text = "Без лишних пробелов";
            this.btnWithoutSuperfluousSpaces.UseVisualStyleBackColor = true;
            this.btnWithoutSuperfluousSpaces.Click += new System.EventHandler(this.btnWithoutSuperfluousSpaces_Click);
            // 
            // btnWithoutParagraph
            // 
            this.btnWithoutParagraph.Location = new System.Drawing.Point(711, 369);
            this.btnWithoutParagraph.Name = "btnWithoutParagraph";
            this.btnWithoutParagraph.Size = new System.Drawing.Size(85, 50);
            this.btnWithoutParagraph.TabIndex = 19;
            this.btnWithoutParagraph.Text = "Без абзацев";
            this.btnWithoutParagraph.UseVisualStyleBackColor = true;
            this.btnWithoutParagraph.Click += new System.EventHandler(this.btnWithoutParagraph_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 482);
            this.Controls.Add(this.btnWithoutParagraph);
            this.Controls.Add(this.btnWithoutSuperfluousSpaces);
            this.Controls.Add(this.btnCharLine);
            this.Controls.Add(this.btnWordLine);
            this.Controls.Add(this.btnTransliteration);
            this.Controls.Add(this.btnInSyllables);
            this.Controls.Add(this.checkBoxAutoReplace);
            this.Controls.Add(this.btnSpacesAfterChar);
            this.Controls.Add(this.btnWithoutConsonants);
            this.Controls.Add(this.btnWithoutVowels);
            this.Controls.Add(this.btnChangeLayout);
            this.Controls.Add(this.btnReplaceTexts);
            this.Controls.Add(this.btnWithoutPunctuation);
            this.Controls.Add(this.btnWithoutSpaces);
            this.Controls.Add(this.btnWordsWithUpper);
            this.Controls.Add(this.newText);
            this.Controls.Add(this.sourceText);
            this.Controls.Add(this.btnToUpper);
            this.Controls.Add(this.btnToLower);
            this.Controls.Add(this.btnLineReverse);
            this.Controls.Add(this.labelNewText);
            this.Controls.Add(this.labelSourceText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(820, 520);
            this.Name = "MainForm";
            this.Text = "Редактор текста";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSourceText;
        private System.Windows.Forms.Label labelNewText;
        private System.Windows.Forms.TextBox sourceText;
        private System.Windows.Forms.TextBox newText;
        private System.Windows.Forms.Button btnReplaceTexts;
        private System.Windows.Forms.Button btnLineReverse;
        private System.Windows.Forms.Button btnToLower;
        private System.Windows.Forms.Button btnToUpper;
        private System.Windows.Forms.Button btnWordsWithUpper;
        private System.Windows.Forms.Button btnWithoutSpaces;
        private System.Windows.Forms.Button btnWithoutPunctuation;
        private System.Windows.Forms.Button btnChangeLayout;
        private System.Windows.Forms.Button btnWithoutVowels;
        private System.Windows.Forms.Button btnWithoutConsonants;
        private System.Windows.Forms.Button btnSpacesAfterChar;
        private System.Windows.Forms.Button btnInSyllables;
        private System.Windows.Forms.Button btnTransliteration;
        private System.Windows.Forms.Button btnWordLine;
        private System.Windows.Forms.CheckBox checkBoxAutoReplace;
        private System.Windows.Forms.Button btnCharLine;
        private System.Windows.Forms.Button btnWithoutSuperfluousSpaces;
        private System.Windows.Forms.Button btnWithoutParagraph;
    }
}

