#include <stdio.h>

int main()
{
    int test;
    scanf("%d", &test);
    for (int i = 0; i < test; i++)
    {
        long long int m;
        long long int a;
        long long int b;
        long long int c;

        scanf("%lld %lld %lld %lld", &m, &a, &b, &c);

            int mul = a * b * c;
            if (m%mul == 0)
            {
                printf("%lld", m/mul);
            }
            else
            {
                printf("-1");
            }
        
    }


    return 0;
}