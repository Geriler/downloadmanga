using AngleSharp.Parser.Html;
using System;
using System.Windows.Forms;

namespace Readmanga.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;
        bool isActive;
        #region Properties
        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }
        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }
        #endregion
        public event Action<object, T, int, int> OnNewData;
        public event Action<object> OnCompleted;
        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }
        public void Start()
        {
            isActive = true;
            Worker();
        }
        public void Abort()
        {
            isActive = false;
        }
        private async void Worker()
        {
            bool isNewData = false, checkNextChapter = false;
            int num_chapter = 0, num_tom = 1;
            if (parserSettings.DowloadAll)
            {
                for (int j = num_tom; j <= parserSettings.NumTom; j++)
                {
                    for (int i = num_chapter; i <= parserSettings.NumChapter; i++)
                    {
                        if (!isActive)
                        {
                            OnCompleted?.Invoke(this);
                            return;
                        }
                        var source = await loader.GetSourceByPageId(j, i);
                        var domParser = new HtmlParser();
                        var document = await domParser.ParseAsync(source);
                        var result = parser.Parse(document);
                        if (result != null)
                        {
                            if (!isNewData)
                            {
                                parserSettings.NumTom++;
                                checkNextChapter = false;
                            }
                            isNewData = true;
                            OnNewData.Invoke(this, result, i, j);
                            num_tom = j;
                            num_chapter = i;
                            parserSettings.NumChapter++;
                        }
                        else
                        {
                            isNewData = false;
                            if (checkNextChapter)
                            {
                                parserSettings.NumChapter--;
                                break;
                            }
                            else
                            {
                                checkNextChapter = true;
                                parserSettings.NumChapter++;
                            }
                        }
                    }
                    checkNextChapter = false;
                }
            }
            else
            {
                for (int i = 0; i <= parserSettings.NumChapter; i++)
                {
                    if (!isActive)
                    {
                        OnCompleted?.Invoke(this);
                        return;
                    }
                    var source = await loader.GetSourceByPageId(parserSettings.NumTom, i);
                    var domParser = new HtmlParser();
                    var document = await domParser.ParseAsync(source);
                    var result = parser.Parse(document);
                    if (result != null)
                    {
                        isNewData = true;
                        OnNewData.Invoke(this, result, i, parserSettings.NumTom);
                    }
                    else
                    {
                        if (isNewData)
                        {
                            break;
                        }
                    }
                }
            }
            OnCompleted?.Invoke(this);
        }
    }
}