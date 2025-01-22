Banco
=====

Funcionalidades:
* Crear cuenta
* TransferirDinero
* ConsultarTransacciones

Crear Cuenta
------------

Regla: el alias de la cuenta debe ser unico
Escenarios:
> * el alias esta disponible
> * el alias NO esta disponible
> * la cuenta es guardada

Transferir Dinero
-----------------

Regla: las cuentas deben existir y la cuenta origen debe tener saldo suficiente
Escenarios:
> * la cuenta origen no existe
> * la cuenta destino no existe
> * la cuenta origen no tiene saldo suficiente
> * la transferencia tiene un identificador
> * la cuenta origen tiene saldo suficiente 

Consultar Transacciones
-----------------------

Regla: la cuenta debe existir
Escenarios:
> * la cuenta no tiene transacciones
> * la cuenta tiene transacciones
> * la cuenta no existe