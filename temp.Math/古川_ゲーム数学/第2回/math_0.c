#include <stdio.h>
#include <math.h>

int main(void)
{
	printf( "直角三角形の斜面の長さを求めます。\n" );

	float side0 = 0.0f;
	float side1 = 0.0f;
	int result = 0;

	printf("斜辺ではない辺の長さ1を入力してください。\n");
	result = scanf( "%f", &side0 );
	if (!result)	return 0;	// 正しく値を取得できなかったので強制終了

	printf("斜辺ではない辺の長さ2を入力してください。\n");
	result = scanf( "%f", &side1 );
	if (!result)	return 0;	// 正しく値を取得できなかったので強制終了

	// sqrtf()	平方根を求める関数
	printf("斜辺の長さ = %f\n", sqrtf(side0 * side0 + side1 * side1));

	return 0;
}
