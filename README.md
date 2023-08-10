# Trapezoidal-Simpsons-Rule
Numerical Integration using Trapezoidal and Simpson's Rule with mXparser math expression evaluator/parser

Numerical integration encompasses a set of techniques to compute approximate values of definite integrals, typically involving partitioning the integration domain, approximating the function's behavior within each partition, and combining these approximations to obtain an overall estimate of the integral's value.

Numerical integration using the Trapezoidal Rule approximates the integral of a function by partitioning the interval into small segments, forming trapezoids with the function's values at the endpoints, and summing their areas, providing an estimation of the integral's value.

Numerical integration using Simpson's Rule approximates the integral by dividing the interval into smaller segments, fitting parabolic curves through sets of three adjacent points, and integrating these curves, yielding a more accurate estimation of the integral than simpler methods like the trapezoidal rule.

The Input Instructions for f(x) will be displayed as a guide for the user to input proper function
that the program can recognize: 
a) Use "^" for exponent (ex.: x^2 instead of x2),
b) Use "*" in coefficient on the term (ex:. 2*x instead of 2x),
c) Use "e" for euler's number (ex.: e^(x-1) instead of exp(x-1)),
d) Use proper operation between terms (ex.: sin(x) * cos(x) instead of sin(x) cos(x)),
e) Enclose the x value with () in every trigonometric function (ex.: cos(x) instead of cos x).

1) Input function f(x)
2) Input the beginning of the interval/s
3) Input the end of the interval/s
4) Input the number of subdivision/s

Result are in the form of 'Value of Integral' and 'Percentage Error' in both Trapezoidal Rule and Simpson's Rule.
