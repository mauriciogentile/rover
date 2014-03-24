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

        [TestMethod]
        public void should_move_back()
        {
            var param = TestHelper.MarsExploration;
            param.PositionInfo.Position = new Point(0, 0);
            var target = new Rover(param);
            target.Move("B");
            Assert.AreEqual(new Point(0, 1), target.GetPositionInfo().Position);
        }

        [TestMethod]
        public void should_move_back_to_the_zero_zero_spot()
        {
            var param = TestHelper.MarsExploration;
            param.PositionInfo.Position = new Point(10, 0);
            param.PositionInfo.Direction = Direction.Right;

            var target = new Rover(param);
            target.Move("BBBBBBBBBB");
            Assert.AreEqual(new Point(0, 0), target.GetPositionInfo().Position);
        }

        [TestMethod]
        public void should_move_back_to_the_zero_zero_spot_when_down()
        {
            var param = TestHelper.MarsExploration;
            param.PositionInfo.Position = new Point(0, 10);
            param.PositionInfo.Direction = Direction.Down;

            var target = new Rover(param);
            target.Move("BBBBBBBBBB");
            Assert.AreEqual(new Point(0, 0), target.GetPositionInfo().Position);
        }

        [TestMethod]
        public void should_turn_to_the_left_when_up_and_L()
        {
            var param = TestHelper.MarsExploration;
            var target = new Rover(param);
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            target.Move("L");
            Assert.AreEqual(Direction.Left, target.GetPositionInfo().Direction);
        }

        [TestMethod]
        public void should_point_down_when_up_and_LL()
        {
            var param = TestHelper.MarsExploration;
            var target = new Rover(param);
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            target.Move("LL");
            Assert.AreEqual(Direction.Down, target.GetPositionInfo().Direction);
        }

        [TestMethod]
        public void should_point_right_when_up_and_LLL()
        {
            var param = TestHelper.MarsExploration;
            var target = new Rover(param);
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            target.Move("LLL");
            Assert.AreEqual(Direction.Right, target.GetPositionInfo().Direction);
        }

        [TestMethod]
        public void should_turn_to_the_right_when_up_and_R()
        {
            var param = TestHelper.MarsExploration;
            var target = new Rover(param);
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            target.Move("R");
            Assert.AreEqual(Direction.Right, target.GetPositionInfo().Direction);
        }

        [TestMethod]
        public void should_point_down_when_up_and_RR()
        {
            var param = TestHelper.MarsExploration;
            var target = new Rover(param);
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            target.Move("RR");
            Assert.AreEqual(Direction.Down, target.GetPositionInfo().Direction);
        }

        [TestMethod]
        public void should_point_left_when_up_and_RRR()
        {
            var param = TestHelper.MarsExploration;
            var target = new Rover(param);
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            target.Move("RRR");
            Assert.AreEqual(Direction.Left, target.GetPositionInfo().Direction);
        }

        [TestMethod]
        public void should_point_up_when_up_and_LR()
        {
            var explorationInfo = TestHelper.MarsExploration;
            var target = new Rover(explorationInfo);
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            target.Move("LR");
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
        }

        [TestMethod]
        public void should_point_up_when_up_and_RL()
        {
            var param = TestHelper.MarsExploration;
            var target = new Rover(param);
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            target.Move("RL");
            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
        }

        [TestMethod]
        public void should_move_to_the_oposite_corner()
        {
            var param = TestHelper.MarsExploration;
            param.Terrain.FarthestPoint = new Point(3, 3);
            var target = new Rover(param);

            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            Assert.AreEqual(new Point(0, 0), target.GetPositionInfo().Position);

            target.Move("RFRFLFRFLFRFLF");

            Assert.AreEqual(Direction.Right, target.GetPositionInfo().Direction);
            Assert.AreEqual(param.Terrain.FarthestPoint, target.GetPositionInfo().Position);
        }

        [TestMethod]
        public void should_move_to_the_oposite_corner_moving_backawrds()
        {
            var param = TestHelper.MarsExploration;
            param.Terrain.FarthestPoint = new Point(3, 3);
            var target = new Rover(param);

            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            Assert.AreEqual(new Point(0, 0), target.GetPositionInfo().Position);

            target.Move("BBBLBBB");

            Assert.AreEqual(Direction.Left, target.GetPositionInfo().Direction);
            Assert.AreEqual(param.Terrain.FarthestPoint, target.GetPositionInfo().Position);
        }

        [TestMethod]
        public void should_do_a_round_trip()
        {
            var param = TestHelper.MarsExploration;
            param.Terrain.FarthestPoint = new Point(3, 3);
            var target = new Rover(param);

            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            Assert.AreEqual(new Point(0, 0), target.GetPositionInfo().Position);

            target.Move("RFRFLFRFLFRFLF");

            Assert.AreEqual(Direction.Right, target.GetPositionInfo().Direction);
            Assert.AreEqual(param.Terrain.FarthestPoint, target.GetPositionInfo().Position);

            target.Move("LFFFLFFFR");

            Assert.AreEqual(Direction.Up, target.GetPositionInfo().Direction);
            Assert.AreEqual(new Point(0, 0), target.GetPositionInfo().Position);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void should_throw_error_when_invalid_commands_are_sent()
        {
            var param = TestHelper.MarsExploration;
            param.Terrain.FarthestPoint = new Point(3, 3);
            var target = new Rover(param);
            target.Move("LFRPpp654");
        }

    }
}