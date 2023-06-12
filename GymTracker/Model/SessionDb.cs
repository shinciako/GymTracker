using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace GymTracker.Model
{
    public class SessionDb
    {
        private SQLiteConnection _connection;

        public SessionDb()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydatabase.db");
            File.Delete(dbPath);
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Session>();
            _connection.CreateTable<Training>();
            _connection.CreateTable<Exercise>();

            _connection.DeleteAll<Exercise>();
            var exercises = new ObservableCollection<Exercise>()
                {
                    new Exercise { Name = "Bench press", MusclePart = "Chest" },
                    new Exercise { Name = "Squat front", MusclePart = "Lower body" },
                    new Exercise { Name = "Squat back", MusclePart = "Lower body" },
                    new Exercise { Name = "Bench press", MusclePart = "Chest" },
                };
            AddExercises(exercises);
        }

        public List<Session> GetSessions()
        {
            return _connection.GetAllWithChildren<Session>().ToList();
        }

        public void AddSession(Session session)
        {
            _connection.InsertWithChildren(session);
        }


        public void AddExercises(IEnumerable<Exercise> exercises)
        {
            foreach (var exercise in exercises)
            {
                _connection.Insert(exercise);
            }
        }

        public List<Exercise> GetExercises()
        {
            return _connection.Table<Exercise>().ToList();
        }

        public void DeleteSession(Session session)
        {
            _connection.Delete(session, recursive: true);
        }

        public void DeleteAllSessions()
        {
            _connection.DeleteAll<Session>();
        }
    }
}
