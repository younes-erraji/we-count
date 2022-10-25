using System;
using System.Linq;
using System.Collections.Generic;

using WeCount.Models;
using WeCount.Data.Helpers;

namespace WeCount.Data.Services
{
    public class ApplicationsService: ICRUD<Application>
    {
        private _DBContext _context;
        public ApplicationsService(_DBContext context)
        {
            _context = context;
        }

        public List<Application> GetEntities() => _context.Applications.OrderByDescending(application => application.CreatedAt).ToList();

        public Application GetEntity(int Id) => _context.Applications.FirstOrDefault(application => application.Id == Id);

        public Application GetEntity(string Slag) => _context.Applications.FirstOrDefault(application => application.Slag == Slag);

        public int DeleteEntity(int Id)
        {
            Application _application = _context.Applications.Find(Id);
            if (_application != null)
            {
                _context.Applications.Remove(_application);
                _context.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int DeleteEntity(string slag)
        {
            Application _application = _context.Applications.FirstOrDefault(application => application.Slag == slag);
            if (_application != null)
            {
                _context.Applications.Remove(_application);
                _context.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Application InsertEntity(Application application)
        {
            Application _application = new()
            {
                FirstName = application.FirstName.Trim(),
                LastName = application.LastName.Trim(),
                Slag = $"{application.FirstName.Trim()}-{application.LastName.Trim()}{DateTime.Now.GetHashCode()}".Replace(" ", "-").ToLower(),
                Mail = application.Mail.ToLower().Trim(),
                Phone = application.Phone.Trim(),
                StudyLevel = application.StudyLevel,
                YearsOfExperinces = application.YearsOfExperinces,
                LastJob = application.LastJob.Trim(),
                Resume = application.Resume
            };

            _context.Applications.Add(_application);
            _context.SaveChanges();

            return _application;
        }

        public Application UpdateEntity(int Id, Application application)
        {
            Application _application = _context.Applications.FirstOrDefault(application => application.Id == Id);
            if (_application != null)
            {
                _application.FirstName = application.FirstName.Trim();
                _application.LastName = application.LastName.Trim();
                _application.Mail = application.Mail.ToLower().Trim();
                _application.Phone = application.Phone.Trim();
                _application.StudyLevel = application.StudyLevel;
                _application.YearsOfExperinces = application.YearsOfExperinces;
                _application.LastJob = application.LastJob.Trim();
                _application.Resume = application.Resume;

                _context.SaveChanges();
            }

            return _application;
        }

        public Application InsertResume(string slag, string Resume)
        {
            Application _application = _context.Applications.FirstOrDefault(application => application.Slag == slag);

            _application.Resume = Resume;
            _context.SaveChanges();

            return _application;
        }

        public string GetSlag(Application application)
        {
            var _application = _context.Applications.SingleOrDefault(
                application =>
                    application.FirstName == application.FirstName
                    && application.LastName == application.LastName
                    && application.Mail == application.Mail
                    && application.LastJob == application.LastJob
                    && application.YearsOfExperinces == application.YearsOfExperinces
                    && application.StudyLevel == application.StudyLevel
                    && application.Phone == application.Phone
            );

            return _application.Slag;
        }

        public List<Application> SearchEntity(string search)
        {
            List<Application> _applications = _context.Applications
                .Where(application => application.FirstName.Contains(search) ||
                                      application.LastName.Contains(search) ||
                                      (application.FirstName + " " + application.LastName).Contains(search) ||
                                      application.Mail.Contains(search))
                .Select(application => application).ToList();

            return _applications;
        }
    }
}
