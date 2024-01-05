#include <stdio.h>
int main()
{
    int t;
    scanf("%d", &t);
    int m1[t], m2[t], d[t];

    for (int i = 0; i < t; i++)
    {
        scanf("%d %d %d", &m1[i], &m2[i], &d[i]);
    }

    for (int i = 0; i < t; i++)
    {
        float days = (m1[i] * d[i]) / (m1[i] + m2[i] * 1.0);

        int intValue = (days/1);
        int k = d[i] - intValue;
        printf("%d\n", k);
    }

    return 0;
}