using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories {

    public class NotificationRepository {

        private CollectionContext _context;

        public NotificationRepository(CollectionContext context) {
            _context = context;
        }

        public List<Notification> GetAll(string AuthId) {
            try {
                return _context.Notifications.Where(n => n.AuthId == AuthId).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        public List<Notification> GetAll() {
            try {
                return _context.Notifications.ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        public Notification Get(int id) {
            try {
                return _context.Notifications.SingleOrDefault(n => n.Id == id);
            } catch (Exception e) {
                throw e;
            }
        }

        public Notification Post(Notification notification) {
            try {
                _context.Notifications.Add(notification);
                _context.SaveChanges();
                return notification;
            } catch (Exception e) {
                throw e;
            }
        }

        public bool Delete(int id) {
            try {
                var notification = _context.Notifications.Find(id);

                if (notification == null)
                    return false;

                _context.Notifications.Remove(notification);
                _context.SaveChanges();
                return true;
            } catch (Exception e) {
                throw e;
            }
        }

    }

}
