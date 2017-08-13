using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class Attachment : Attachment<string>
    {
    }

    public class Attachment<TKey> : IAttachment<TKey>
    {
        public TKey Id { get; set; }
        public TKey ProcessInstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// the remote URL in case this is remote content.  If the attachment content was 
        /// {@link TaskService#createAttachment(String, String, String, String, String, java.io.InputStream) uploaded with an input stream}, 
        /// then this method returns null and the content can be fetched with {@link TaskService#getAttachmentContent(String)}.
        /// </summary>
        public string Url { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
