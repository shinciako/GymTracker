using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.IO;
using System.Linq;

namespace GymTracker.Model
{
    public class SessionDb
    {
        private SQLiteConnection _connection;

        public SessionDb()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydatabase.db");
            bool isNewDatabase = !File.Exists(dbPath);
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Session>();
            _connection.CreateTable<Training>();
            _connection.CreateTable<Exercise>();

            if (isNewDatabase)
            {
                var exercises = new ObservableCollection<Exercise>()
                {
                    new Exercise { Name = "Bench press", MusclePart = "Chest" },
                    new Exercise { Name = "Dip", MusclePart = "Chest" },
                    new Exercise { Name = "Plate press", MusclePart = "Chest" },
                    new Exercise { Name = "Squat front", MusclePart = "Lower body" },
                    new Exercise { Name = "Squat back", MusclePart = "Lower body" },
                    new Exercise { Name = "Leg curl", MusclePart = "Lower body" },
                    new Exercise { Name = "Deadlift", MusclePart = "Lower body" },
                };
                AddExercises(exercises);
            }
        }

        public List<Session> GetSessions()
        {
            return _connection.GetAllWithChildren<Session>(recursive: true).ToList();
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
    }
}
