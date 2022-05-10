using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repeating.Service
{
    public class RecordService
    {
        private readonly ManagementContext _context;

        public RecordService(ManagementContext context)
        {
            _context = context;
        }

        public void DeleteRecord(int id)
        {
            var record = _context.Records.FirstOrDefault(recordblablabla => recordblablabla.Id == id);
            if (record != null)
            {
                _context.Records.Remove(record);
                _context.SaveChanges();
            }
        }

        public void ChangeRecordUser(int recordId, User user)
        {
            var record = _context.Records.FirstOrDefault(recordblablabla => recordblablabla.Id == recordId);

            if (record != null)
            {
                record.User = user;
                _context.Records.Update(record);
                _context.SaveChanges();
            }
        }

        public void CreateRecord(string title, string content, int userId)
        {
            var record = new Record() { Title = title, Content = content, UserId = userId };

            _context.Records.Add(record);
            _context.SaveChanges();
        }



    }
}
