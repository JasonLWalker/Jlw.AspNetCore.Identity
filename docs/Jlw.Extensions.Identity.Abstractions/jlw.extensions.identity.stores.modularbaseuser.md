[`< Back`](./)

---

# ModularBaseUser

Namespace: Jlw.Extensions.Identity.Stores

```csharp
public class ModularBaseUser : Jlw.Extensions.Identity.ModularBaseUser`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], Jlw.Extensions.Identity.IModularBaseUser`2[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e],[Microsoft.AspNetCore.Identity.IdentityUserClaim`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], Microsoft.Extensions.Identity.Stores, Version=9.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60]], Jlw.Extensions.Identity.IModularBaseUser`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], IModularBaseUser, IModularBaseUser`1, IModularBaseUser`2, Jlw.Extensions.Identity.IModularBaseUser
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → IdentityUser&lt;String&gt; → [ModularBaseUser&lt;String, IdentityUserClaim&lt;String&gt;&gt;](./jlw.extensions.identity.modularbaseuser-2.md) → [ModularBaseUser&lt;String&gt;](./jlw.extensions.identity.modularbaseuser-1.md) → [ModularBaseUser](./jlw.extensions.identity.stores.modularbaseuser.md)<br>
Implements [IModularBaseUser&lt;String, IdentityUserClaim&lt;String&gt;&gt;](./jlw.extensions.identity.imodularbaseuser-2.md), [IModularBaseUser&lt;String&gt;](./jlw.extensions.identity.imodularbaseuser-1.md), [IModularBaseUser](./jlw.extensions.identity.stores.imodularbaseuser.md), [IModularBaseUser&lt;String&gt;](./jlw.extensions.identity.stores.imodularbaseuser-1.md), [IModularBaseUser&lt;String, IdentityUserClaim&lt;String&gt;&gt;](./jlw.extensions.identity.stores.imodularbaseuser-2.md), [IModularBaseUser](./jlw.extensions.identity.imodularbaseuser.md)

## Properties

### **SecurityStamp**

```csharp
public string SecurityStamp { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Claims**

The user's claims, for use in claims-based authentication.

```csharp
public ICollection<IdentityUserClaim<string>> Claims { get; }
```

#### Property Value

[ICollection&lt;IdentityUserClaim&lt;String&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<br>

### **Id**

```csharp
public string Id { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **UserName**

```csharp
public string UserName { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **NormalizedUserName**

```csharp
public string NormalizedUserName { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Email**

```csharp
public string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **NormalizedEmail**

```csharp
public string NormalizedEmail { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **EmailConfirmed**

```csharp
public bool EmailConfirmed { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **PasswordHash**

```csharp
public string PasswordHash { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ConcurrencyStamp**

```csharp
public string ConcurrencyStamp { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PhoneNumber**

```csharp
public string PhoneNumber { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PhoneNumberConfirmed**

```csharp
public bool PhoneNumberConfirmed { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **TwoFactorEnabled**

```csharp
public bool TwoFactorEnabled { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **LockoutEnd**

```csharp
public Nullable<DateTimeOffset> LockoutEnd { get; set; }
```

#### Property Value

[Nullable&lt;DateTimeOffset&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **LockoutEnabled**

```csharp
public bool LockoutEnabled { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **AccessFailedCount**

```csharp
public int AccessFailedCount { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **ModularBaseUser()**

```csharp
public ModularBaseUser()
```

### **ModularBaseUser(IModularBaseUser)**

```csharp
public ModularBaseUser(IModularBaseUser data)
```

#### Parameters

`data` [IModularBaseUser](./jlw.extensions.identity.stores.imodularbaseuser.md)<br>

### **ModularBaseUser(Object)**

```csharp
public ModularBaseUser(object o)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

---

[`< Back`](./)
