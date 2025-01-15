Ejemplo03: Cuenta Bancaria

Reglas:

1. Se crea indicando alias
2. Al crearse el saldo es cero
3. Acreditar incremental el saldo
4. Debitar decrementa el saldo
5. No puede debitar más allá del saldo
6. Debe llevar un historial de transacciones

Diseño preliminar
Cuenta
Transacción
AliasNoValidoException
TransaccionInvalidaException 

Escenarios:
1. modelo: se crea con alias > ok
2. modelo: se crea con saldo cero > ok
3. modelo: creación falla por alias vacío (empty o null) > ok
4. modelo: creación falla por alias muy largo (mayor a 20) > ok
5. acreditar: un monto positivo > ok
6. acreditar: monto negativo > ok
> refactor de los tests para agruparlos
7. debitar: monto positivo > ok
8. debitar: monto negativo > ok
9. debitar: más allá del saldo > ok
10. historial: cuando es creada (cero transacciones) > ok
11. historial: cuando hay 1 transacción de credito > ok
12. historial: cuando hay varias transaccion de debito y credito > ok
13. modelo transaccion: tiene el monto > ok
