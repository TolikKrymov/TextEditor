using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TextChanger {
    public partial class MainForm : Form {
        //Постоянные для пользовательских размеров
        const int marginFirstColumn = 195;
        const int marginSecondColum = 109;
        
        #region Массивы символов и строк для замены и проверок
        char[] engChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
        char[] rusChars = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".ToCharArray();
        char[] engLayoutChars = "qwertyuiop[]asdfghjkl;'zxcvbnm,./QWERTYUIOP{}ASDFGHJKL:\"ZXCVBNM<>?@#$&".ToCharArray();
        char[] rusLayoutChars = "йцукенгшщзхъфывапролджэячсмитьбю.ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,\"№;?".ToCharArray();
        char[] vowels = "уеыаояиюэёУЕЫАОЯИЮЭЁeyuioaEYUIOA".ToCharArray();
        char[] rusVowels = "уеыаояиюэёУЕЫАОЯИЮЭЁ".ToCharArray();
        char[] consonants = "йцкнгшщзхъфвпрлджчсмтьбЙЦКНГШЩЗХЪФВПРЛДЖЧСМТЬБqwrtpsdfghjklzxcvbnmQWRTPSDFGHJKLZXCVBNM".ToCharArray();
        char[] punctuation = ".,-!?\\/;:()…—".ToCharArray();
        string[] engTransl = new string[] {
            "j", "c", "u", "k", "e", "n", "g", "sh", "shh", "z", "h",
            "\"", "f", "y", "v", "a", "p", "r", "o", "l", "d", "zh",
            "je", "ya", "ch", "s", "m", "i", "t", "'", "b", "yu",
            "J", "C", "U", "K", "E", "N", "G", "SH", "Shh", "Z", "H",
            "\"", "F", "Y", "V", "A", "P", "R", "O", "L", "D", "Zh",
            "Je", "Ya", "Ch", "S", "M", "I", "T", "'", "B", "Yu"
        };
        #endregion

        public MainForm() { InitializeComponent(); }
        
        // Для доступа к тексту нужного поля
        public string _Text {
            get { if (checkBoxAutoReplace.Checked) return textBoxSource.Text; return textBoxNew.Text; }
            set { if (checkBoxAutoReplace.Checked) textBoxSource.Text = value; else textBoxNew.Text = value; }
        }

        // Все буквы строчные
        private void btnToLower_Click(object sender, EventArgs e) => _Text = textBoxSource.Text.ToLower();

        //Все буквы прописные
        private void btnToUpper_Click(object sender, EventArgs e) => _Text = textBoxSource.Text.ToUpper();

        //Строки наоборот
        private void btnLineReverse_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            int prestartLine = -1;
            for (int i = 0; i != chars.Length; i++) {
                if (chars[i] == '\n') {
                    for (int j = i - 1; j != prestartLine; j--)
                        text += chars[j];
                    text += "\r\n";
                    prestartLine = i;
                }
            }
            if (prestartLine != chars.Length - 1)
                for (int i = chars.Length - 1; i != prestartLine; i--)
                    text += chars[i];
            _Text = text;
        }

        //Все слова с большой буквы
        private void btnWordsWithUpper_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            int end = chars.Length;
            for (int i = 0; i != end; i++) {
                text += chars[i];
                if ((chars[i] == ' ' || chars[i] == '\n') && i + 1 < end)
                    text += chars[++i].ToString().ToUpper();
            }
            _Text = text;
        }

        //Заменить исходный текст новым
        private void btnReplaceTexts_Click(object sender, EventArgs e) {
            textBoxSource.Text = textBoxNew.Text;
            textBoxNew.Text = string.Empty;
        }

        //Без пробелов
        private void btnWithoutSpaces_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            foreach (char c in chars)
                if (c != ' ')
                    text += c;
            _Text = text;
        }

        //Без пунктуации
        private void btnWithoutPunctuation_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            foreach (char c in chars) {
                bool add = true;
                foreach (char p in punctuation)
                    if (p == c) {
                        add = false;
                        break;
                    }
                if (add)
                    text += c;
            }
            _Text = text;
        }

        //Изменить раскладку
        private void btnChangeLayout_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
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
                string text = string.Empty;
                foreach (char c in chars)
                    text += c;
                _Text = text;
            }
        }

        //Без гласных
        private void btnWithoutVowels_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            foreach (char c in chars) {
                bool add = true;
                foreach (char g in vowels)
                    if (g == c) {
                        add = false;
                        break;
                    }
                if (add)
                    text += c;
            }
            _Text = text;
        }

        //Без согласных
        private void btnWithoutConsonants_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            foreach (char c in chars) {
                bool add = true;
                foreach(char s in consonants)
                    if (s == c) {
                        add = false;
                        break;
                    }
                if (add)
                    text += c;
            }
            _Text = text;
        }

        //С пробелами через символ
        private void btnWithSpacesAfterSChar_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            foreach (char c in chars)
                if (c != ' ')
                    if (c != '\r' && c != '\n')
                        text += c + " ";
                    else
                        text += c;
            _Text = text;
        }

        //Включение/выключение автозамены
        private void checkBoxAutoReplace_CheckedChanged(object sender, EventArgs e) {
            labelNewText.Visible =
                btnReplaceTexts.Visible =
                textBoxNew.Visible =
                btnReplaceTexts.Enabled = !checkBoxAutoReplace.Checked;
            textBoxSource.Size = checkBoxAutoReplace.Checked ?
                new Size( Size.Width - marginFirstColumn - 5 - 13         , textBoxSource.Size.Height) :
                new Size((Size.Width - marginFirstColumn - 5 - 13 - 7) / 2, textBoxSource.Size.Height);
        }

        //По слогам
        private void btnInSyllables_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
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
                        text += SplitWord(word);
                        word = string.Empty;
                    }
                    text += chars[i];
                }
            }
            if (word != string.Empty)
                text += SplitWord(word);
            _Text = text;
        }

        //Деление слова на слоги, между слогами ставится дефис
        string SplitWord(string word) {
            string value = string.Empty;
            char[] cWord = word.ToCharArray();
            Stack<char> stack = new Stack<char>();
            stack.Push(cWord[cWord.Length - 1]);
            for (int j = cWord.Length - 1; j > 0; j--) {
                bool isntVowel = true;
                foreach (char c in rusVowels)
                    if (cWord[j] == c) {
                        isntVowel = false;
                        stack.Push(cWord[j]);
                        j--;
                        if (j != 0) {
                            bool isNotVowel = true;
                            foreach (char c2 in rusVowels)
                                if (c2 == cWord[j]) {
                                    isNotVowel = false;
                                }
                            if (isNotVowel)
                                stack.Push(cWord[j]);
                            stack.Push('-');
                        }
                    }
                if (isntVowel)
                    stack.Push(cWord[j]);
            }
            stack.Push(cWord[0]);
            for (int j = stack.Count - 1; j != 0; j--)
                value += stack.Pop();
            return value;
        }

        //Транслит
        private void btnTransliteration_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            for (int i = 0; i != chars.Length; i++) {
                bool b = true;
                for (int j = 0; j != rusChars.Length; j++)
                    if (chars[i] == rusChars[j]) {
                        text += engTransl[j];
                        b = false;
                        break;
                    }
                if (b)
                    text += chars[i];
            }
            _Text = text;
        }

        //Слово-строка
        private void btnWordLine_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            foreach (char c in chars)
                if (c != '\r' && c != '\n') {
                    text += c;
                    if (c == ' ')
                        text += "\r\n";
                }
            _Text = text;
        }

        //Изменение размера окна
        private void MainForm_Resize(object sender, EventArgs e) {
            //Позиции и размеры
            int positionFirstColumn   = Size.Width - marginFirstColumn;
            int positionSecondColumn  = Size.Width - marginSecondColum;
            int widthTextBox          = (positionFirstColumn - 5 - 13 - 7) / 2;
            int positionLastLine      = Size.Height - 80;
            int positionSecondTextBox = textBoxSource.Location.X + widthTextBox + 5;
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
            textBoxNew.Size = textBoxSource.Size = new Size(widthTextBox, positionLastLine + 10);
            //Изменение второго поля ввода и надписи "Новый текст"
            textBoxNew.Location   = new Point(positionSecondTextBox, textBoxNew.Location.Y);
            labelNewText.Location = new Point(positionSecondTextBox, labelNewText.Location.Y);
        }

        //Символ-строка
        private void btnCharLine_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            foreach (char c in chars)
                if (c != '\r') {
                    if (c != '\n')
                        text += c + "\r\n";
                }
                else
                    text += "\r\n";
            _Text = text;
        }

        //Без лишних пробелов
        private void btnWithoutSuperfluousSpaces_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.Trim().ToCharArray();
            string text = string.Empty;
            if (chars.Length > 0) {
                text += chars[0];
                for (int i = 1; i != chars.Length - 1; i++)
                    if (chars[i] != ' ')
                        text += chars[i];
                    else if (chars[i - 1] != ' ' && chars[i - 1] != '\n' && chars[i + 1] != '\r')
                        text += chars[i];
                if (chars.Length > 1 && chars[chars.Length - 1] != ' ')
                    text += chars[chars.Length - 1];
                _Text = text;
            }
        }

        //Без абзацев
        private void btnWithoutParagraph_Click(object sender, EventArgs e) {
            char[] chars = textBoxSource.Text.ToCharArray();
            string text = string.Empty;
            foreach (char c in chars)
                if (c != '\r' && c != '\n')
                    text += c;
            _Text = text;
        }
    }
}