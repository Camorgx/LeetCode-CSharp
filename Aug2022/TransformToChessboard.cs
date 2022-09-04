// https://leetcode.cn/problems/transform-to-chessboard/

namespace TransformToChessboard {
    public static class Test {
        public static void RunTest() {
            int[][] test1 = new int[][] {
                new int[] { 0, 1, 1, 0 },
                new int[] { 0, 1, 1, 0 },
                new int[] { 1, 0, 0, 1 },
                new int[] { 1, 0, 0, 1 }
            };
            int[][] test2 = new int[][] {
                new int[] { 0, 1 },
                new int[] { 1, 0 }
            };
            int[][] test3 = new int[][] {
                new int[] { 1, 0 },
                new int[] { 1, 0 }
            };

            Solution solution = new();
            Console.WriteLine(solution.MovesToChessboard(test1));
            Console.WriteLine(solution.MovesToChessboard(test2));
            Console.WriteLine(solution.MovesToChessboard(test3));
        }
    }
    public class Solution {
        public int MovesToChessboard(int[][] board) {
            // Mask 表示使用二进制压位存储的矩阵行或列
            uint rowMask = 0, colMask = 0;
            for (int i = 0; i < board.Length; ++i) {
                rowMask |= (uint)board[0][i] << i;
                colMask |= (uint)board[i][0] << i;
            }
            uint reverseRowMask = (uint)((1 << board.Length) - 1) ^ rowMask;
            uint reverseColMask = (uint)((1 << board.Length) - 1) ^ colMask;
            int colCount = 0, rowCount = 0;
            for (int i = 0; i < board.Length; ++i) {
                uint currentRowMask = 0, currentColMask = 0;
                for (int j = 0; j < board[i].Length; ++j) {
                    currentRowMask |= (uint)board[i][j] << j;
                    currentColMask |= (uint)board[j][i] << j;
                }
                if (currentColMask != colMask && currentColMask != reverseColMask)
                    return -1;
                else if (currentColMask == colMask) ++colCount;
                if (currentRowMask != rowMask && currentRowMask != reverseRowMask)
                    return -1;
                else if (currentRowMask == rowMask) ++rowCount;
            }
            int rowMoves = GetMoveCount(rowMask, rowCount, board.Length);
            int colMoves = GetMoveCount(colMask, colCount, board.Length);
            if (rowMoves == -1 || colMoves == -1) return -1;
            else return rowMoves + colMoves;
        }
        // mask 是使用二进制压位存储的矩阵行或列
        // count 是与第一行或第一列相同的行或列的数目
        // n 是矩阵的大小
        private static int GetMoveCount(uint mask, int count, int n) {
            int ones = CountBit(mask);
            if ((n & 1) == 1) {
                // 如果 n 为奇数，则每一行中 1 与 0 的数目相差为 1，且满足相邻行交替
                if (Math.Abs(n - 2 * ones) != 1 || Math.Abs(n - 2 * count) != 1)
                    return -1;
                // 只保留偶数位上的 1 与 0xAAAAAAAA 按位与
                // 只保留偶数位上的 1 与 0x55555555 按位与
                if (ones == (n >> 1)) return n / 2 - CountBit(mask & 0xAAAAAAAA);
                else return (n + 1) / 2 - CountBit(mask & 0x55555555);
            }
            else {
                // 如果 n 为偶数，则每一行中 1 与 0 的数目相等，且满足相邻行交替
                if (ones != (n >> 1) || count != (n >> 1)) return -1;
                return Math.Min(n / 2 - CountBit(mask & 0xAAAAAAAA),
                    n / 2 - CountBit(mask & 0x55555555));
            }
        }
        private static int CountBit(uint mask) {
            int ans = 0;
            while (mask != 0) {
                mask &= (mask - 1);
                ++ans;
            }
            return ans;
        }
    }
}
