INSERT INTO growth_rate(id,[name],formula) VALUES (1,'slow','\frac{5x^3}{4}');
INSERT INTO growth_rate(id,[name],formula) VALUES (2,'medium','x^3');
INSERT INTO growth_rate(id,[name],formula) VALUES (3,'fast','\frac{4x^3}{5}');
INSERT INTO growth_rate(id,[name],formula) VALUES (4,'medium-slow','\frac{6x^3}{5} - 15x^2 + 100x - 140');
INSERT INTO growth_rate(id,[name],formula) VALUES (5,'slow-then-very-fast','\begin{cases}
\frac{ x^3 \left( 100 - x \right) }{50},    & \text{if } x \leq 50  \\
\frac{ x^3 \left( 150 - x \right) }{100},   & \text{if } 50 < x \leq 68  \\
\frac{ x^3 \left( 1274 + (x \bmod 3)^2 - 9 (x \bmod 3) - 20 \left\lfloor \frac{x}{3} \right\rfloor \right) }{1000}, & \text{if } 68 < x \leq 98  \\
\frac{ x^3 \left( 160 - x \right) }{100},   & \text{if } x > 98  \\
\end{cases}');
INSERT INTO growth_rate(id,[name],formula) VALUES (6,'fast-then-very-slow','\begin{cases}')
