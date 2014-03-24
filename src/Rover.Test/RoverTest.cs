using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Threading.Tasks;

namespace MarsRover.Test
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void should_start_at_init_position()
        {
            var param = TestHelper.MarsExploration;
            param.PositionInfo.Position = new Point(2, 2);
            var target = new Rover(param);
            Assert.AreEqual(param.PositionInfo.Position, target.GetPositionInfo().Position);
        }

        [TestMethod]
        public void should_start_heading_north()
        {
            var param = TestHelper.MarsExploration;
            var target = new Rover(param);
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
        }

        [TestMethod]
        public void should_move_ahead()
        {
            var param = TestHelper.MarsExploration;
            param.PositionInfo.Position = new Point(0, 2);
            var target = new Rover(param);
            target.Move("F");
            Assert.AreEqual(new Point(0, 1), target.GetPositionInfo().Position);
        }

        [TestMethod]
        public void should_stay_at_the_last_available_spot_if_found_a_boundary()
        {
            var param = TestHelper.MarsExploration;
            param.PositionInfo.Position = new Point(0, 2);
            var target = new Rover(param);
            target.Move("FF");
            Assert.AreEqual(new Point(0, 0), target.GetPositionInfo().Position);
        }
    }
}