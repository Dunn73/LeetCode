
Solution solution = new();
int[] positions = [3,5,2,6];
int[] healths = [10,10,15,12];
string directions = "RLRL";

var output = solution.SurvivedRobotsHealths(positions, healths, directions);

foreach (var element in output) {
    Console.WriteLine(element);
}

Console.ReadKey();

public class Solution {
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions) {
        int n = positions.Length;
        var robots = new List<Robot>();

        // Initialize robots
        for (int i = 0; i < n; i++) {
            robots.Add(new Robot(positions[i], healths[i], directions[i], i));
        }

        // Sort robots by their positions
        robots.Sort((a, b) => a.Position.CompareTo(b.Position));

        // Use a stack to handle collisions
        Stack<Robot> stack = new Stack<Robot>();

        for (int i = 0; i < robots.Count; i++) {
            Robot robot = robots[i];
            while (stack.Count > 0 && stack.Peek().Direction == 'R' && robot.Direction == 'L') {
                var lastRobot = stack.Pop();
                
                if (lastRobot.Health > robot.Health) {
                    lastRobot.Health--;
                    stack.Push(lastRobot);
                    robot = null;
                    break;
                } else if (lastRobot.Health < robot.Health) {
                    robot.Health--;
                } else {
                    robot = null;
                    break;
                }
            }
            if (robot != null) {
                stack.Push(robot);
            }
        }

        // Extract the health of survived robots and map them back to their original indices
        var survivedRobots = stack.ToList();
        survivedRobots.Sort((a, b) => a.Index.CompareTo(b.Index));

        return survivedRobots.Select(r => r.Health).ToList();
    }

    public class Robot {
        public int Position { get; }
        public int Health { get; set; }
        public char Direction { get; }
        public int Index { get; }

        public Robot(int position, int health, char direction, int index) {
            Position = position;
            Health = health;
            Direction = direction;
            Index = index;
        }
    }
}