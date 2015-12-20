using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextChanger {
    public partial class MainForm : Form {
        //Sizes
        const int marginFirstColumn = 195;
        const int marginSecondColum = 109;
        
        #region Array of character and strings for replacing and checking
        char[] engChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
        char[] rusChars = "йцукенгшщзхъфывапролджэячсмитьбюёЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ".ToCharArray();
        char[] engLayoutChars = "qwertyuiop[]asdfghjkl;'zxcvbnm,./QWERTYUIOP{}ASDFGHJKL:\"ZXCVBNM<>?@#$&".ToCharArray();
        char[] rusLayoutChars = "йцукенгшщзхъфывапролджэячсмитьбю.ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,\"№;?".ToCharArray();
        char[] vowels = "уеыаояиюэёУЕЫАОЯИЮЭЁeyuioaEYUIOA".ToCharArray();
        char[] rusVowels = "уеыаояиюэёУЕЫАОЯИЮЭЁ".ToCharArray();
        char[] consonants = "йцкнгшщзхъфвпрлджчсмтьбЙЦКНГШЩЗХЪФВПРЛДЖЧСМТЬБqwrtpsdfghjklzxcvbnmQWRTPSDFGHJKLZXCVBNM".ToCharArray();
        char[] punctuation = ".,-!?\\/;:()…—".ToCharArray();
        string[] engTransl = new string[] {
            "j", "c", "u", "k", "e", "n", "g", "sh", "shh", "z", "h",
            "\"", "f", "y", "v", "a", "p", "r", "o", "l", "d", "zh",
            "je", "ya", "ch", "s", "m", "i", "t", "'", "b", "yu", "yo",
            "J", "C", "U", "K", "E", "N", "G", "SH", "Shh", "Z", "H",
            "\"", "F", "Y", "V", "A", "P", "R", "O", "L", "D", "Zh",
            "Je", "Ya", "Ch", "S", "M", "I", "T", "'", "B", "Yu", "Yo"
        };
        #endregion

        public MainForm() { InitializeComponent(); }
        
        // For access to text of selected field
        string TextInForm {
            set {
                if (checkBoxAutoReplace.Checked)
                    sourceText.Text = value;
                else
                    newText.Text = value;
            }
        }

        // Все буквы строчные
        private void btnToLower_Click(object sender, EventArgs e) {
            TextInForm = sourceText.Text.ToLower();
        }

        //Все буквы прописные
        private void btnToUpper_Click(object sender, EventArgs e) {
            TextInForm = sourceText.Text.ToUpper();
        }

        //Строки наоборот
        private void btnLineReverse_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            StringBuilder sb = new StringBuilder(chars.Length);
            string text = string.Empty;
            int prestartLine = -1;
            for (int i = 0; i != chars.Length; i++) {
                if (chars[i] == '\n') {
                    for (int j = i - 1; j != prestartLine; j--)
                        sb.Append(chars[j]);
                    sb.Append("\r\n");
                    prestartLine = i;
                }
            }
            if (prestartLine != chars.Length - 1)
                for (int i = chars.Length - 1; i != prestartLine; i--)
                    sb.Append(chars[i]);
            TextInForm = sb.ToString();
        }

        //Все слова с большой буквы
        private void btnWordsWithUpper_Click(object sender, EventArgs e) {
            if (sourceText.Text.Length != 0) {
                char[] chars = sourceText.Text.ToCharArray();
                StringBuilder sb = new StringBuilder(chars.Length);
                sb.Append(char.ToUpper(chars[0]));
                for (int i = 1; i < chars.Length; i++)
                    if (chars[i - 1] == ' ' || chars[i - 1] == '\n')
                        sb.Append(char.ToUpper(chars[i]));
                    else
                        sb.Append(chars[i]);
                TextInForm = sb.ToString();
            }
        }

        //Заменить исходный текст новым
        private void btnReplaceTexts_Click(object sender, EventArgs e) {
            sourceText.Text = newText.Text;
            newText.Text = string.Empty;
        }

        //Без пробелов
        private void btnWithoutSpaces_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            StringBuilder sb = new StringBuilder(sourceText.Text.Length);
            for (int i = 0; i != chars.Length; i++)
                if (chars[i] != ' ')
                    sb.Append(chars[i]);
            TextInForm = sb.ToString();
        }

        //Без пунктуации
        private void btnWithoutPunctuation_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            StringBuilder sb = new StringBuilder(chars.Length);
            foreach (char c in chars) {
                foreach (char p in punctuation)
                    if (c == p)
                        goto end;
                sb.Append(c);
                end:;
            }
            TextInForm = sb.ToString();
        }

        //Изменить раскладку
        private void btnChangeLayout_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            if (chars.Length != 0) {
                int engCharsCount = 0;
                int rusCharsCount = 0;
                foreach (char c in chars) {
                    foreach (char engChar in engChars)
                        if (c == engChar) {
                            engCharsCount++;
                            goto end;
                        }
                    foreach (char rusChar in rusChars)
                        if (c == rusChar) {
                            rusCharsCount++;
                            goto end;
                        }
                    end:
                    continue;
                }
                if (rusCharsCount < engCharsCount) {
                    for (int i = 0; i != chars.Length; i++)
                        for (int j = 0; j != engLayoutChars.Length; j++)
                            if (chars[i] == engLayoutChars[j]) {
                                chars[i] = rusLayoutChars[j];
                                break;
                            }
                }
                else
                    for (int i = 0; i != chars.Length; i++)
                        for (int j = 0; j != rusLayoutChars.Length; j++)
                            if (chars[i] == rusLayoutChars[j]) {
                                chars[i] = engLayoutChars[j];
                                break;
                            }
                TextInForm = new string(chars);
            }
        }

        //Без гласных
        private void btnWithoutVowels_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            StringBuilder sb = new StringBuilder(sourceText.Text.Length);
            foreach (char c in chars) {
                bool add = true;
                foreach (char v in vowels)
                    if (v == c) {
                        add = false;
                        break;
                    }
                if (add)
                    sb.Append(c);
            }
            TextInForm = sb.ToString();
        }

        //Без согласных
        private void btnWithoutConsonants_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            StringBuilder sb = new StringBuilder(sourceText.Text.Length);
            foreach (char c in chars) {
                bool add = true;
                foreach(char s in consonants)
                    if (s == c) {
                        add = false;
                        break;
                    }
                if (add)
                    sb.Append(c);
            }
            TextInForm = sb.ToString();
        }

        //С пробелами через символ
        private void btnWithSpacesAfterSChar_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            StringBuilder sb = new StringBuilder(sourceText.Text.Length);
            foreach (char c in chars)
                if (c != ' ')
                    if (c != '\r' && c != '\n')
                        sb.Append(c + " ");
                    else
                        sb.Append(c);
            TextInForm = sb.ToString();
        }

        //Включение/выключение автозамены
        private void checkBoxAutoReplace_CheckedChanged(object sender, EventArgs e) {
            labelNewText.Visible =
                btnReplaceTexts.Visible =
                newText.Visible =
                btnReplaceTexts.Enabled = !checkBoxAutoReplace.Checked;
            sourceText.Size = checkBoxAutoReplace.Checked ?
                new Size( Size.Width - marginFirstColumn - 5 - 13         , sourceText.Size.Height) :
                new Size((Size.Width - marginFirstColumn - 5 - 13 - 7) / 2, sourceText.Size.Height);
        }

        //По слогам
        private void btnInSyllables_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            StringBuilder sb = new StringBuilder(sourceText.Text.Length);
            string word = string.Empty;
            for (int i = 0; i != chars.Length; i++) {
                bool b = true;
                foreach (char c in rusChars)
                    if (chars[i] == c) {
                        word += c;
                        b = false;
                        break;
                    }
                if (b) {
                    if (word != string.Empty) {
                        sb.Append(SplitWord(word));
                        word = string.Empty;
                    }
                    sb.Append(chars[i]);
                }
            }
            if (word != string.Empty)
                sb.Append(SplitWord(word));
            TextInForm = sb.ToString();
        }

        //Деление слова на слоги, между слогами ставится дефис
        string SplitWord(string word) {
            bool[] isVowel = new bool[word.Length];
            char[] chars = word.ToCharArray();
            for (int i = 0; i != chars.Length; i++)
                foreach (char v in vowels)
                    if (chars[i] == v) {
                        isVowel[i] = true;
                        break;
                    }
            StringBuilder sb = new StringBuilder(word.Length * 2);
            Stack<char> stack = new Stack<char>(word.Length * 2);
            for (int i = chars.Length - 1; i > 0; i--) {
                if (isVowel[i]) {
                    stack.Push(chars[i]);
                    if (i > 0) {
                        if (isVowel[i - 1])
                            stack.Push('-');
                        else {
                            for (int j = i - 1; j > 0; j--)
                                if (isVowel[j]) {
                                    stack.Push(chars[--i]);
                                    stack.Push('-');
                                    break;
                                }
                        }
                    }
                }
                else
                    stack.Push(chars[i]);
            }
            sb.Append(chars[0]);
            while (stack.Count != 0)
                sb.Append(stack.Pop());
            return sb.ToString();
        }

        //Транслит
        private void btnTransliteration_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            StringBuilder sb = new StringBuilder(sourceText.Text.Length * 2);
            for (int i = 0; i != chars.Length; i++) {
                bool b = true;
                for (int j = 0; j != rusChars.Length; j++)
                    if (chars[i] == rusChars[j]) {
                        sb.Append(engTransl[j]);
                        b = false;
                        break;
                    }
                if (b)
                    sb.Append(chars[i]);
            }
            TextInForm = sb.ToString();
        }

        //Слово-строка
        private void btnWordLine_Click(object sender, EventArgs e) {
            StringBuilder sb = new StringBuilder(sourceText.Text.Length * 2);
            foreach (char c in sourceText.Text)
                if (c != '\r' && c != '\n') {
                    sb.Append(c);
                    if (c == ' ')
                        sb.Append("\r\n");
                }
            TextInForm = sb.ToString();
        }

        //Изменение размера окна
        private void MainForm_Resize(object sender, EventArgs e) {
            //Позиции и размеры
            int positionFirstColumn   = Size.Width - marginFirstColumn;
            int positionSecondColumn  = Size.Width - marginSecondColum;
            int widthTextBox          = (positionFirstColumn - 5 - 13 - 7) / 2;
            int positionLastLine      = Size.Height - 80;
            int positionSecondTextBox = sourceText.Location.X + widthTextBox + 5;
            //Первый столбец кнопок
            btnLineReverse.Location              = new Point(positionFirstColumn, btnLineReverse.Location.Y);
            btnToLower.Location                  = new Point(positionFirstColumn, btnToLower.Location.Y);
            btnChangeLayout.Location             = new Point(positionFirstColumn, btnChangeLayout.Location.Y);
            btnWithoutSpaces.Location            = new Point(positionFirstColumn, btnWithoutSpaces.Location.Y);
            btnWithoutConsonants.Location        = new Point(positionFirstColumn, btnWithoutConsonants.Location.Y);
            btnInSyllables.Location              = new Point(positionFirstColumn, btnInSyllables.Location.Y);
            btnWordLine.Location                 = new Point(positionFirstColumn, btnWordLine.Location.Y);
            btnWithoutSuperfluousSpaces.Location = new Point(positionFirstColumn, btnWithoutSuperfluousSpaces.Location.Y);
            //Второй столбец кнопок
            btnWordsWithUpper.Location     = new Point(positionSecondColumn, btnWordsWithUpper.Location.Y);
            btnToUpper.Location            = new Point(positionSecondColumn, btnToUpper.Location.Y);
            btnTransliteration.Location    = new Point(positionSecondColumn, btnTransliteration.Location.Y);
            btnSpacesAfterChar.Location    = new Point(positionSecondColumn, btnSpacesAfterChar.Location.Y);
            btnWithoutVowels.Location      = new Point(positionSecondColumn, btnWithoutVowels.Location.Y);
            btnWithoutPunctuation.Location = new Point(positionSecondColumn, btnWithoutPunctuation.Location.Y);
            btnCharLine.Location           = new Point(positionSecondColumn, btnCharLine.Location.Y);
            btnWithoutParagraph.Location   = new Point(positionSecondColumn, btnWithoutParagraph.Location.Y);
            //Кнопка автозамены и кнопка замещения исходного текста
            btnReplaceTexts.Location     = new Point(positionFirstColumn, positionLastLine);
            checkBoxAutoReplace.Location = new Point(positionSecondColumn, positionLastLine);
            //Изменение размеров полей ввода
            newText.Size = sourceText.Size = new Size(widthTextBox, positionLastLine + 10);
            //Изменение второго поля ввода и надписи "Новый текст"
            newText.Location   = new Point(positionSecondTextBox, newText.Location.Y);
            labelNewText.Location = new Point(positionSecondTextBox, labelNewText.Location.Y);
        }

        //Символ-строка
        private void btnCharLine_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            StringBuilder sb = new StringBuilder(sourceText.Text.Length * 3);
            foreach (char c in chars) {
                if (c != '\r' && c != '\n')
                    sb.Append(c);
                sb.Append("\r\n");
            }
            TextInForm = sb.ToString();
        }

        //Без лишних пробелов
        private void btnWithoutSuperfluousSpaces_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.Trim().ToCharArray();
            StringBuilder sb = new StringBuilder(sourceText.Text.Length);
            if (chars.Length > 0) {
                sb.Append(chars[0]);
                for (int i = 1; i != chars.Length - 1; i++)
                    if (chars[i] != ' ')
                        sb.Append(chars[i]);
                    else if (chars[i - 1] != ' ' && chars[i - 1] != '\n' && chars[i + 1] != '\r')
                        sb.Append(chars[i]);
                if (chars.Length > 1 && chars[chars.Length - 1] != ' ')
                    sb.Append(chars[chars.Length - 1]);
                TextInForm = sb.ToString();
            }
        }

        //Без абзацев
        private void btnWithoutParagraph_Click(object sender, EventArgs e) {
            char[] chars = sourceText.Text.ToCharArray();
            StringBuilder sb = new StringBuilder(sourceText.Text.Length);
            foreach (char c in chars)
                if (c != '\r' && c != '\n')
                    sb.Append(c);
            TextInForm = sb.ToString();
        }
    }
}