using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Repositories;

namespace Services {

    public class NotificationService {

        private NotificationRepository _notificationRepository;

        public NotificationService(NotificationRepository notificationRepository) {
            _notificationRepository = notificationRepository;
        }

        public List<Notification> GetAll() {
            return _notificationRepository.GetAll();
        }

        public List<Notification> GetAll(string AuthId) {
            return _notificationRepository.GetAll(AuthId);
        }

        public Notification Get(int id) {
            return _notificationRepository.Get(id);
        }

        public Notification Post(Notification notification) {
            return _notificationRepository.Post(notification);
        }

        public bool Delete(int id) {
            return _notificationRepository.Delete(id);
        }
    }
}
