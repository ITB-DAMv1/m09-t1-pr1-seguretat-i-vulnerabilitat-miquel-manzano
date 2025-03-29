# T1. PR1. Seguretat i vulnerabilitat



1. **L’organització [OWASP Foundation](https://owasp.org/Top10/es/) va actualitzar en 2021 el seu Top 10 de vulnerabilitats més trobades en aplicacions web.** 

![](Res/mapping.png)

- **Escull 3 vulnerabilitats d’aquesta llista i descriu-les. Escriu l’impacte que tenen a la seguretat i quins danys pot arribar a fer un atac en aquesta vulnerabilitat. Enumera diferents mesures i tècniques per poder evitar-les.**

1. **Injecció de codi (Injection)**
   - **Impacte**: Permet a un atacant executar codi maliciós en la base de dades o el sistema afectat, comprometent la integritat de les dades.
   - **Danys potencials**: Fuga d'informació, alteració de dades, accés no autoritzat.
   - **Mesures de prevenció**:
     - Ús de sentències preparades (Prepared Statements).
     - Validació estricta d'entrada de dades.
     - Limitació de privilegis en la base de dades.

2. **Autenticació trencada (Broken Authentication)**
   - **Impacte**: Permet als atacants obtenir accés no autoritzat a comptes d'usuaris.
   - **Danys potencials**: Robatori d'identitat, accés a informació sensible, ús maliciós de comptes.
   - **Mesures de prevenció**:
     - Autenticació multifactorial (MFA).
     - Emmagatzematge segur de contrasenyes (bcrypt, Argon2).
     - Sessions segures i amb temps d'expiració.

3. **Exposició de dades sensibles (Sensitive Data Exposure)**
   - **Impacte**: La informació sensible pot ser robada o interceptada.
   - **Danys potencials**: Pèrdua de privacitat, frau financer, ús indegut de dades personals.
   - **Mesures de prevenció**:
     - Cifrat de dades en trànsit i en repòs (TLS, AES-256).
     - Control d’accés rigorós.
     - Evitar emmagatzemar dades sensibles innecessàries.


---


2. **Obre el següent enllaç ([sql inseckten](https://www.sql-insekten.de/)) i realitza un mínim de 7 nivells fent servir tècniques d’injecció SQL.**   
   - **Copia cada una de les sentències SQL resultant que has realitzat a cada nivell i comenta que has aconseguit.**  
   - **Enumera i raona diferents formes que pot evitar un atac per SQL injection en projectes fets amb Razor Pages i Entity Framework.** 

   Consideraciones de seguridad a seguir segun la documentacion de EF:
   - Use solo proveedores de orígenes de datos de confianza
   - Cifre la conexión para proteger los datos confidenciales
   - Proteja la cadena de conexión
   - No exponga EntityConnection a usuarios que no sean de confianza
   - No pase las conexiones fuera del contexto de seguridad
   - Tenga cuenta que la información de inicio de sesión y las contraseñas pueden quedar visibles en un volcado de memoria
   - Conceda a los usuarios únicamente los permisos necesarios en el origen de datos
   - Ejecute las aplicaciones con los permisos mínimos
   - No instale aplicaciones que no sean de confianza
   - Restrinja el acceso a todos los archivos de configuración
   - Restrinja los permisos a los archivos de asignación y de modelo

   Consideraciones de seguridad para las consultas a la base de datos
   - Impida los ataques de inyección de SQL
   - Evite conjuntos de resultados muy grandes
   - Evitar devolver resultados de IQueryable al exponer métodos a autores de llamadas que pueden no ser de confianza

https://learn.microsoft.com/es-es/dotnet/framework/data/adonet/ef/security-considerations

3. **L’empresa a la qual treballes desenvoluparà una aplicació web de venda d’obres d’art. Els artistes registren les seves obres amb fotografies, títol, descripció i preu.  Els clients poden comprar les obres i poden escriure ressenyes públiques dels artistes a qui han comprat. Tant clients com artistes han d’estar registrats. L’aplicació guarda nom, cognoms, adreça completa, dni i telèfon. En el cas dels artistes guarda les dades bancaries per fer els pagaments. Hi ha un tipus d’usuari Acount Manager que s’encarrega de verificar als nous artistes. Un cop aprovats poden pública i vendre les seves obres.**

   **Ara es vol aplicar aplicant els principis  de seguretat per tal de garantir el servei i la integritat de les dades. T’han encarregat l'elaboració de part de les polítiques de seguretat. Elabora els següents apartats:**  
   - **Definició del control d’accés: enumera els rols  i quin accés a dades tenen cada rol.**   

    | Rol | Accés |
    |------|-------|
    | Client | Comprar obres, deixar ressenyes (A de estar registrat)|
    | Artista | Publicar i vendre obres (A de estar registrat, guarda dades bancaries)|
    | Account Manager | Aprovar artistes |
    | Admin | Accés complet |
   - **Definició de la política de contrasenyes: normes de creació, d’ús i canvi de contrasenyes. Raona si són necessàries diferents polítiques segons el perfil d’usuari.**  

        - Mínim **12 caràcters**, combinació de majúscules, minúscules, números i símbols.
        - Canvi cada **90 dies**.
        - Bloqueig temporal després de **5 intents fallits**.

   - **Avaluació de la informació: determina quin valor tenen les dades que treballa l'aplicació. Determina com tractar les dades més sensibles. Quines dades encriptaries?**
        - **Dades a encriptar**: DNI, telèfon, dades bancàries.
        - Utilitzaria un mètode d'encriptació per guardar a la base de dades les dades més sensibles.


---


4. **En el control d’accessos, existeixen mètodes d’autenticació basats en tokens. Defineix l’autenticació basada en tokens. Quins tipus hi ha? Com funciona mitjançant la web? Cerca llibreries .Net que ens poden ajudar a implementar autenticació amb tokens.**


---


5. **Crea un projecte de consola amb un menú amb tres opcions:**  
   - **Registre: l’usuari ha d’introduir username i una password. De la combinació dels dos camps guarda en memòria directament l'encriptació. Utilitza l’encriptació de hash SHA256. Mostra per pantalla el resultat.**  
   - **Verificació de dades: usuari ha de tornar a introduir les dades el programa mostra per pantalla si les dades són correctes.**  
   - **Encriptació i desencriptació amb RSA. L’usuari entrarà un text per consola. A continuació mostra el text encriptat i en la següent línia el text desencriptat. L’algoritme de RSA necessita una clau pública per encriptar i una clau privada per desencriptar. No cal guardar-les en memòria persistent.**

	**Per realitzar aquest exercici utilitza la llibreria System.Security.Cryptography.**

6.  **Indica les referències que has consultat, seguint el següent format:**








[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/S9WTUTwx)