
Program vectoresocho;

Const 
  ingresantes = 3;

Type 

  alumno = Record
    dni: integer;
    apellido: string;
    nombre: string;
    nacimiento: integer;
  End;

  vector = array[1..ingresantes] Of alumno;



Procedure leer(Var a:alumno);
Begin
  writeln('ingrese dni');
  readln(a.dni);
  writeln('ingrese apellido');
  readln(a.apellido);
  writeln('ingrese nombre');
  readln(a.nombre);
  writeln('ingrese nacimiento');
  readln(a.nacimiento);
End;

Procedure cargar(Var v:vector);

Var i: integer;
Begin
  For i:=1 To 3 Do
    leer(v[i]);
End;

Function cumple(num:integer): boolean;
Begin
  If (num Mod 2=0 ) Then
    cumple := true;
  cumple := false ;
End;

Procedure procesar(Var v:vector; Var maxEdad1,maxEdad2:integer;Var nombreMaxEdad1,apellidoMaxEdad1,nombreMaxEdad2,apellidoMaxEdad2:integer);

Var i: integer;
  par: integer;
Begin
  par := 0;
  For i:=1 To 3 Do
    Begin
      If (cumple(v[i].dni)) Then par := par + 1 ;

      If (v[i].nacimiento > maxEdad1) Then
        Begin
          maxEdad2 := maxEdad1;
          maxEdad1 := v[i].nacimiento;
          apellidoMaxEdad2 := apellidoMaxEdad1;
          nombreMaxEdad2 := nombreMaxEdad1;
          apellidoMaxEdad1 := v[i].apellido;
          nombreMaxEdad1 := v[i].nombre;
        End
      Else If (v[i].nacimiento > maxEdad2) Then
             Begin
               maxEdad2 := v[i].nacimiento;
               apellidoMaxEdad2 := v[i].apellido;
               nombreMaxEdad2 := v[i].nombre;
             End;

    End;

  writeln('Porcentaje de alumnos con DNI compuesto solo por dígitos pares: ',(par/3));
  writeln('Apellido y nombre de los dos alumnos de mayor edad:');
  writeln('1. ', apellidoMaxEdad1, ', ', nombreMaxEdad1);
  writeln('2. ', apellidoMaxEdad2, ', ', nombreMaxEdad2);

End;

Var 
  v: vector;
  a: alumno;
  maxEdad1, maxEdad2: integer;
  apellidoMaxEdad1, nombreMaxEdad1, apellidoMaxEdad2, nombreMaxEdad2: string;

Begin
  maxEdad1 := -1;
  maxEdad2 := -1;
  cargar(v);
  procesar(v,maxEdad1,maxEdad2,nombreMaxEdad1,apellidoMaxEdad1,nombreMaxEdad2,apellidoMaxEdad2);
   
End.
