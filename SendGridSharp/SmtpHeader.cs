using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace SendGridSharp
{
    public class SmtpHeader
    {
        private readonly List<string> _to = new List<string>();
        private readonly List<DateTimeOffset> _sendAt = new List<DateTimeOffset>();
        private readonly List<string> _categories = new List<string>();
        private readonly Dictionary<string, IList<string>> _substitutions = new Dictionary<string, IList<string>>();
        private readonly Dictionary<string, string> _uniqueArgs = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _sections = new Dictionary<string, string>();
        private readonly Dictionary<string, object> _filters = new Dictionary<string, object>();

        private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
            NullValueHandling = NullValueHandling.Ignore
        };

        public void AddTo(params string[] addresses)
        {
            _to.AddRange(addresses);
        }

        public void AddTo(IList<string> addresses)
        {
            _to.AddRange(addresses);
        }

        public void AddSendAt(params DateTimeOffset[] dateTimes)
        {
            _sendAt.AddRange(dateTimes);
        }

        public void AddSendAt(IList<DateTimeOffset> dateTimes)
        {
            _sendAt.AddRange(dateTimes);
        }

        public void AddSubstitution(string tag, params string[] substitutions)
        {
            _substitutions.Add(tag, substitutions);
        }

        public void AddSubstitution(string tag, IList<string> substitutions)
        {
            _substitutions.Add(tag, substitutions);
        }

        public void AddUniqueArg(string key, string value)
        {
            _uniqueArgs.Add(key, value);
        }

        public void AddUniqueArg(IDictionary<string, string> args)
        {
            foreach (var item in args)
            {
                _uniqueArgs.Add(item.Key, item.Value);
            }
        }

        public void AddCategory(params string[] categories)
        {
            _categories.AddRange(categories);
        }

        public void AddCategory(IList<string> categories)
        {
            _categories.AddRange(categories);
        }

        public void AddSection(string tag, string text)
        {
            _sections.Add(tag, text);
        }

        public void AddFilter(string name, IDictionary<string, object> settings)
        {
            _filters.Add(name, new { settings });
        }

        public override string ToString()
        {
            var data = new Dictionary<string, object>();

            if (_to.Count != 0)
            {
                data.Add("to", _to.Count == 1 ? _to[0] : (object)_to);
            }

            if (_categories.Count != 0)
            {
                data.Add("category", _categories.Count == 1 ? _categories[0] : (object)_categories);
            }

            if (_substitutions.Count != 0)
            {
                data.Add("sub", _substitutions);
            }

            if (_uniqueArgs.Count != 0)
            {
                data.Add("unique_args", _uniqueArgs);
            }

            if (_sections.Count != 0)
            {
                data.Add("section", _sections);
            }

            if (_filters.Count != 0)
            {
                data.Add("filters", _filters);
            }

            if (_sendAt.Count != 0)
            {
                if (_sendAt.Count == 1)
                {
                    data.Add("send_at", (long)(_sendAt[0].UtcDateTime - _unixEpoch).TotalSeconds);
                }
                else
                {
                    data.Add("send_each_at", _sendAt.Select(p => (long)(p.UtcDateTime - _unixEpoch).TotalSeconds).ToArray());
                }
            }

            if (data.Count == 0)
            {
                return "";
            }

            return JsonConvert.SerializeObject(data, _settings);
        }
    }
}
