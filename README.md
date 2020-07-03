# RegaloBot
Este es Bot Interactivo llamado *Regala_Bot* el cual a través de una serie de datos brindados por el usuario realiza la busqueda en Mercado Libre aplicando filtros para recomendarte qué le podrías regalar a una persona.
Desde que el bot se inicia cualquier persona que utilice la plataforma Telegram y/o consola podrá comunicarse con él, respondiendo una serie de preguntas para poder definir el mejor regalo.

Tambien teníamos pensado utilizar TextAnalitics de Azure para obtener del usuario ciertas palabras claves en una frase y no tener la necesidad de hacerle una pregunta si ya nos habria brindado ese dato (así no era tan repetitivo), pero al final nos decidimos por una serie de preguntas en un orden especifico (edad, género, relación,interes, precio máximo y precio mínimo) ya que nos pareció más organizado y por temas de tiempo estaba más a nuestro alcance.

Utilizamos MLscrapper para buscar en las tendencias y recomendar las cosas que más se buscan en ML en cada categoría.

Este bot utiliza archivos que contienen todas las interacciones/Preguntas al usuario (Busqueda,Despedida,Edad,Genero,Intereses,NoEntendi,PrecioMax,PrecioMin,Relacion,Saludo) los cuales son totalmente configurables en cualquier momento.

Al interactuar con el usuario si este mismo ingresa palabras las cuales no se pueden entender o imagenes,gif,archivos,etc le pedira una aclaración y le enviara un gif.

Teníamos pensado utilizar reply keyboards para facilitar la comunicación con el usuario (utilizando la botonera de Telegram pero no nos dió el tiempo para perfeccionar esto así que decidimos retirarlo).
