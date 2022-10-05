// https://leetcode.cn/problems/subdomain-visit-count/

using CommonStructure;

namespace Oct2022 {
    public class SubdomainVisitCount : ITestable {
        public void RunTest() {
            var tests = new string[][] {
                new string[] { "9001 discuss.leetcode.com" },
                new string[] {
                    "900 google.mail.com",
                    "50 yahoo.com",
                    "1 intel.mail.com",
                    "5 wiki.org"
                }
            };
            var solution = new Solution();
            foreach (var test in tests) {
                var res = solution.SubdomainVisits(test);
                foreach (var item in res)
                    Console.WriteLine(item);
                Console.WriteLine();
            }
        }
        public class Solution {
            public IList<string> SubdomainVisits(string[] cpdomains) {
                IList<string> ans = new List<string>();
                IDictionary<string, int> counts = new Dictionary<string, int>();
                foreach (string cpdomain in cpdomains) {
                    int spacePos = cpdomain.IndexOf(' ');
                    int count = int.Parse(cpdomain[..spacePos]);
                    string domain = cpdomain[(spacePos + 1)..];
                    if (!counts.ContainsKey(domain))
                        counts.Add(domain, 0);
                    counts[domain] += count;
                    for (int i = 0; i < domain.Length; ++i) {
                        if (domain[i] == '.') {
                            string subdomain = domain[(i + 1)..];
                            if (!counts.ContainsKey(subdomain))
                                counts.Add(subdomain, 0);
                            counts[subdomain] += count;
                        }
                    }
                }
                foreach (var (subdomain, count) in counts)
                    ans.Add(count + " " + subdomain);
                return ans;
            }
        }
    }
}
