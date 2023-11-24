#include <bits/stdc++.h>
using namespace std;

class Student{
    public:
    string nm;
    int cls;
    char s;
    int id;
};
int main()
{
    
   int t;
   cin >> t;
   Student s[t];
   for (int i = 0; i < t; i++)
   {
        cin >> s[i].nm >> s[i].cls >> s[i].s >> s[i].id;
   }

   int f = 0;
   int b = t-1;

    while(f < b)
    {
        char temp = s[f].s;
        s[f].s = s[b].s;
        s[b].s = temp;

        f++;
        b--;
    }

   for (int i = 0; i < t; i++)
   {
        cout << s[i].nm << " " <<s[i].cls << " "<<s[i].s << " "<< s[i].id <<endl;
   }
   
    return 0;
}