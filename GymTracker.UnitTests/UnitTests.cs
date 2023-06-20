using FluentAssertions;
using NSubstitute;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace GymTracker.UnitTests;

public class UnitTests
{
    [Fact]
    public void AddExercise_ShouldAddExerciseToTrainings()
    {
        var viewModel = new RegisterWorkoutViewModel(null);
        var exercise = new Exercise { Id = 1, Name = "Exercise 1" };
        viewModel.AddExercise(exercise);
        viewModel.Trainings.Should().HaveCount(1);
        viewModel.Trainings.First().Exercise.Should().Be(exercise);
    }

    [Fact]
    public void ClearTraining_ShouldClearTrainings()
    {
        var viewModel = new RegisterWorkoutViewModel(null);
        var exercise = new Exercise { Id = 1, Name = "Exercise 1" };
        viewModel.AddExercise(exercise);
        viewModel.ClearTrainingImpl();
        viewModel.Trainings.Should().BeEmpty();
    }
}
