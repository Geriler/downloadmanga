using AngleSharp.Parser.Html;
using System;

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
        private async void Worker()
        {
            bool isNewData = false, checkNextChapter = false;
            if (parserSettings.DowloadAll)
            {
                for (int j = parserSettings.NumTom; j <= parserSettings.NumTom; j++)
                {
                    for (int i = parserSettings.NumChapterFirst; i <= parserSettings.NumChapterFirst; i++)
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
                            parserSettings.NumChapterFirst++;
                        }
                        else
                        {
                            isNewData = false;
                            if (parserSettings.NumTom == 0)
                            {
                                parserSettings.NumTom++;
                            }
                            if (checkNextChapter)
                            {
                                parserSettings.NumChapterFirst--;
                                break;
                            }
                            else
                            {
                                checkNextChapter = true;
                                parserSettings.NumChapterFirst++;
                            }
                        }
                    }
                    checkNextChapter = false;
                }
            }
            else
            {
                for (int i = parserSettings.NumChapterFirst; i <= parserSettings.NumChapterLast; i++)
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