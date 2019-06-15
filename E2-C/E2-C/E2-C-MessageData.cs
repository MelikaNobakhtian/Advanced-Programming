using System;
using System.Globalization;

namespace E2.Linq
{
    public class MessageData
    {
        public int Id { get; set; }
        public int? ReplyMessageId { get; set; }
        public string Author { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        
        public MessageData(string[] row)
        {
            Id = int.Parse(row[0]);

            try
            {
                ReplyMessageId = int.Parse(row[1]);
            }
            catch (FormatException e)
            {
                ReplyMessageId = null;
            }

            Author = row[2];
            DateTime = System.DateTime.Parse(row[3]);
            Content = row[4];
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(ReplyMessageId)}: {ReplyMessageId}, {nameof(Author)}: {Author}, {nameof(DateTime)}: {DateTime}, {nameof(Content)}: {Content}";
        }
    }
}