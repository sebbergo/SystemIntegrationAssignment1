### Setup

**Step 1: Run the program in Visual Studio 2022**

> :warning: Make sure you select multiple start up projects to include both the Soap and Rest api

**Step 2: Send a post request to *https://localhost:44307/PersonInviterWebService.asmx* with the following body:


```xml
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GenerateInvitationsFromRestApi xmlns="http://tempuri.org/">
      <inputInvitationDto>
        <Persons>
          <Person>
            <Name>Phillip</Name>
            <Mail>Phillip.andersen1999@gmail.com</Mail>
            <IpAddress>176.23.218.202</IpAddress>
          </Person>
           <Person>
            <Name>Sebastian</Name>
            <Mail>Sebastian@godskhansen</Mail>
            <IpAddress>176.23.218.202</IpAddress>
          </Person>
        </Persons>
        <InvitationMessage>Hey nice bloinde girl</InvitationMessage>
      </inputInvitationDto>
    </GenerateInvitationsFromRestApi>
  </soap:Body>
</soap:Envelope>
```

> :warning: Make sure that you have set Content-Type to test/xml




