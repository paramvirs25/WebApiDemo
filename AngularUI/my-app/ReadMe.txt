* For communication of Angualr app with Web-API, we need to enable "Access-Control-Allow-Origin", so that cross domin requests can go through. So add following to web.config of Web-API:

<system.webServer>
    <httpProtocol>
     <customHeaders>
       <add name="Access-Control-Allow-Origin" value="*" />
     </customHeaders>
   </httpProtocol>
</system.webServer>
