using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class MailTypeBusiness
    {
        public MailTypeEntityCollection FillFilter()
        {
            MailTypeEntityCollection MailTypeEC = this.GetAll();
            MailTypeEntity Todos = new MailTypeEntity();
            Todos.Name = "Todos";
            Todos.Id = 0;
            MailTypeEC.Insert(0, Todos);
            return MailTypeEC;
        }

        public List<MailTypeEntity> GetAllMails()
        {
            MailGroupEntity group = new MailGroupEntity();
            group.Name = "Configuración de Mail";

            List<MailTypeEntity> list = null;

            var configs = new PhxConfigBusiness().GetMails();
            List<PhxConfigEntity> mails = configs.CollectionToList<PhxConfigEntity>();

            var subjects = (from m in mails
                            where m.Code.StartsWith("@SUBJECT")
                            select m).ToList();
            var bodies = (from m in mails
                          where m.Code.StartsWith("@BODY")
                          select m).ToList();

            PhxConfigEntity body = null;
            PhxConfigEntity subject = null;
            List<PhxConfigEntity> matches = null;

            string title = string.Empty;
            string description = string.Empty;

            var groups = new List<MailTypeEntity>();

            foreach (var s in subjects)
            {
                title = string.Empty;
                description = string.Empty;

                subject = s;

                matches = bodies.Where(o => o.Code.EndsWith(s.Code.Replace("@SUBJECT", string.Empty))).ToList();

                if (matches != null && matches.Count > 0)
                {
                    body = matches[0];

                    title = GetTitle(subject.Name);
                    description = GetTitle(subject.Description);

                    groups.Add(new MailTypeEntity(groups.Count + 1, title, description, subject, body, group));

                    if (matches.Count > 1)
                    {
                        body = matches[1];

                        groups.Add(new MailTypeEntity(groups.Count + 1, title, description, subject, body, group));
                    }
                }
            }

            if (groups != null & groups.Count > 0)
            {
                list = groups;
            }
            else
            {
                list = new List<MailTypeEntity>();
            }

            return list;
        }

        public void Save(MailTypeEntity entity)
        {
            List<PhxConfigEntity> configs = new List<PhxConfigEntity>();

            configs.Add(entity.Subject);
            configs.Add(entity.Body);

            new PhxConfigBusiness().Save(configs);
        }

        private MailTypeEntityCollection GetAll()
        {
            return new MailTypeFactory().GetAll();
        }

        private string GetTitle(string value)
        {
            string title = string.Empty;

            title = value.Replace("Subject de email", "Mail")
                    .Replace("Body de email", "Mail")
                    .Replace("Asunto de mails", "Mail")
                    .Replace("Cuerpo del mail", "Mail")
                    .Replace("Asunto de mail", "Mail")
                    .Replace("Cuerpo de mail", "Mail")
                    .Replace("Subject de mail", "Mail")
                    .Replace("Subject del mail", "Mail");

            return title;
        }
    }
}
