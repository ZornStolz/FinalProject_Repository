# Como usar los datos

## > De forma general

la propiedad que necesitan para acceder a los datos en  forma general es:

 `List<Municipio> MunicipiosSet`

 En ella tendran una lista con todos los municipios.

 Cada objeto Municipio cuenta con:
 ```
private double latitud;
private double longitud;
private string departamento;
private string nombre_del_municipio;
private List<Variable_Registrada> variables;
 ```
Esos son los atributos pero recuerden que para esos atributos estan las propiedades.

La lista de `Variable_Registrada` tendra las tres variables que estamos usando. las variables tiene estos datos.

```
private string variable;
private string unidades;
private double concentracion;
```

La `concentracion` esta promediada.

## > Para obtener una lista de datos

Como vieron los municipios guardan info de la concentracion en promedio, si quieren consultar los datos que dieron origen a ese promedio esta lo siguiete.

el metodo ` public void consultarDatos(string municipio, string variable, int year, int limite)`

les va a dar todos los datos de conentracion de la variable que escogieron del municipio que escogieron un year puntual. Eso se veria de la siguienete manera segun que tantos datos quieran por el limite de filas:
```
[{"concentraci_n":"27.09"}
,{"concentraci_n":"26.89"}
,{"concentraci_n":"57.34"}
,{"concentraci_n":"65.77"}
,{"concentraci_n":"73.36"}
,{"concentraci_n":"82.17"}
,{"concentraci_n":"83.27"} .....
```


la transformacion de esa consulta ya esta y los datos se guardan en una lista `private List<Concentracion_Registro> consulta` entonces ahi tendrian todas las concentraciones medidas en de el municipio, variable y year elegidos.

**Asi** solo tendrian que acceder a la propiedad de la lista `consulta` para recorrer y sacar dato por dato.

### Final Words

***Notas***

- El filtro por fecha aun no esta implementada en la consulta.
- Solo se estan consultando 3 valores para  calular el promedio de cada variable de cada municipio ya que serian muchos objetos en memoria y tomaria mucho tiempo para que cargaran los promerdios de los municipios. *Por su puesto* esto es momentaneo mientras hacemos pruebas y todo funciona.
- si ven promedios de 0 o valores raros no se  preocupen se corregira. De momento ignoren los.

***Recordar***  

-  Primereo el metodo `consultarDatos(...)` y luego ya acceden a la lista `consulta`.
- los datos en "general" estan en la propiedad `MunicipiosSet`
