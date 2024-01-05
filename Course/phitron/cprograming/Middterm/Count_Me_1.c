#include <stdio.h>
int main()
{
int n;
scanf("%d",&n);
int a[n];

for (int i = 0; i < n; i++)
{
    scanf("%d",&a[i]);
}
int o = 0, e = 0;

for (int i = 0; i < n; i++)
{
    if (a[i]%2==0)
    {
       o++;
    }else if (a[i]%3==0)
    {
        e++;
    }
}
    
    printf("%d %d",o,e);

    return 0;
}