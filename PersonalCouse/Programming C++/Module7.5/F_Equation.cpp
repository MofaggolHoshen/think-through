#include <bits/stdc++.h>
using namespace std;

int main()
{
    int x, n;
    double s = 0;
    cin >>x>>n;

    for (int i = 2; i < n; i += 2)
    {
        s += pow(x,i);       
    }
    
    cout<<s<<endl;
    
    return 0;
}