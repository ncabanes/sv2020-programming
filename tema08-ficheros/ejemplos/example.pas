program example;
var
  i: integer;
  max: integer;
begin
  writeLn('How many times?');
  readLn(max);
  for i := 1 to max do
    writeLn('Hello');
  if max > 10 then
    write('(More than 10 times...!)');
end.
