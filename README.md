
# Ejercicio 1 - Validador de Tarjetas algoritmo de Luhn

## Descripcion

Este proyecto corresponde al primer ejercicio del modulo de Fundamentos de C# y .NET.

Desarrolle una aplicacion de consola que permite validar numeros de tarjetas de credito y debito utilizando el algoritmo de Luhn. Ademas, el programa identifica la marca de la tarjeta, permite validar varias tarjetas desde un archivo de texto, generar un numero valido y mostrar estadisticas de las validaciones realizadas.

---

## Funcionalidades

El programa cuenta con un menu que permite realizar las siguientes opciones:

1. Validar una tarjeta.
2. Validar tarjetas desde un archivo de texto.
3. Generar un numero valido.
4. Mostrar estadisticas de las validaciones realizadas.
5. Salir del programa.

---

## Marcas identificadas

El programa reconoce las siguientes marcas:

- Visa
- Mastercard
- American Express
- Discover
- Desconocida

---

## Tecnologias utilizadas

- C#
- .NET
- Visual Studio Code

---

## Archivos del proyecto

- Program.cs: Contiene toda la logica del programa.
- tarjetas.txt: Archivo utilizado para realizar pruebas de validacion desde archivo.
- CapturasDePantalla: Carpeta con las evidencias solicitadas en la actividad.

---

## Manejo de errores

El programa valida que:

- El usuario ingrese unicamente numeros.
- No se ingresen valores vacios.
- El archivo exista antes de leerlo.
- Se controlen posibles errores mediante bloques try-catch.

---

## Como ejecutar el proyecto

1. Descargar o clonar el repositorio.
2. Abrir la carpeta del proyecto en Visual Studio Code.
3. Ejecutar el proyecto con el siguiente comando:

```bash
dotnet run
```

---

## Autor

Jesus Garcia
