using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace MarsRover.Test
{
    [TestClass()]
    public class TerrainTest
    {
        [TestMethod()]
        public void should_add_obstacle()
        {
            var target = new Terrain();
            var obstacle = new Point();
            target.AddObstacle(obstacle);
            Assert.IsTrue(target.HasObstacleAt(obstacle));
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void should_throw_error_when_adding_out_of_bound_obstacle()
        {
            var target = new Terrain { FarthestPoint = new Point(10, 10) };
            var obstacle = new Point(11, 11);
            target.AddObstacle(obstacle);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void should_throw_error_when_adding_out_of_bound_obstacle_1()
        {
            var target = new Terrain { FarthestPoint = new Point(10, 10) };
            var obstacle = new Point(0, 11);
            target.AddObstacle(obstacle);
        }

        [TestMethod()]
        public void should_remove_existng_obstacle()
        {
            var target = new Terrain();
            var obstacle = new Point();
            target.AddObstacle(obstacle);
            Assert.IsTrue(target.HasObstacleAt(obstacle));
            target.RemoveObstacle(obstacle);
            Assert.IsFalse(target.HasObstacleAt(obstacle));
        }

        [TestMethod()]
        public void should_return_out_bands()
        {
            var target = new Terrain { FarthestPoint = new Point(10, 10) };

            Assert.IsTrue(target.IsOutOfBounds(new Point(0, 11)));
            Assert.IsTrue(target.IsOutOfBounds(new Point(-1, 11)));
            Assert.IsTrue(target.IsOutOfBounds(new Point(-1, 10)));
            Assert.IsTrue(target.IsOutOfBounds(new Point(11, 11)));
        }
    }
}
