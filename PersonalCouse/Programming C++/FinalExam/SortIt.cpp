#include <bits/stdc++.h>
using namespace std;

class Student
{
public:
    string nm;
    char s;
    int cls, id, math_marks, eng_marks;
};

bool comp(Student a, Student b)
{
    if ((a.math_marks + a.eng_marks) == (b.math_marks + b.eng_marks))
    {
        if (a.id < b.id)
            return true;
        else
            return false;
    }
    else
    {
        if ((a.math_marks + a.eng_marks) > (b.math_marks + b.eng_marks))
            return true;
        else
            return false;
    }
}

int main()
{

    int t;
    cin >> t;
    Student s[t];
    for (int i = 0; i < t; i++)
    {
        cin >> s[i].nm >> s[i].cls >> s[i].s >> s[i].id >> s[i].math_marks >> s[i].eng_marks;
    }

    sort(s, s + t, comp);

    for (int i = 0; i < t; i++)
    {
        cout << s[i].nm << " " << s[i].cls << " " << s[i].s << " " << s[i].id << " " << s[i].math_marks << " " << s[i].eng_marks << endl;
    }

    return 0;
}