[`< Back`](./)

---

# ModularBaseUser&lt;TKey&gt;

Namespace: Jlw.Extensions.Identity.Stores

```csharp
public class ModularBaseUser<TKey> : , , IModularBaseUser`1, IModularBaseUser`2
```

#### Type Parameters

`TKey`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → IdentityUser&lt;TKey&gt; → ModularBaseUser&lt;TKey, IdentityUserClaim&lt;TKey&gt;&gt; → [ModularBaseUser&lt;TKey&gt;](./jlw.extensions.identity.stores.modularbaseuser-1.md)<br>
Implements IModularBaseUser&lt;TKey, IdentityUserClaim&lt;TKey&gt;&gt;, IModularBaseUser&lt;TKey&gt;, IModularBaseUser&lt;TKey, IdentityUserClaim&lt;TKey&gt;&gt;

## Properties

### **SecurityStamp**

```csharp
public string SecurityStamp { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Claims**

```csharp
public ICollection<IdentityUserClaim<TKey>> Claims { get; }
```

#### Property Value

ICollection&lt;IdentityUserClaim&lt;TKey&gt;&gt;<br>

### **Id**

```csharp
public TKey Id { get; set; }
```

#### Property Value

TKey<br>

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

### **ModularBaseUser(IModularBaseUser&lt;TKey&gt;)**

```csharp
public ModularBaseUser(IModularBaseUser<TKey> data)
```

#### Parameters

`data` IModularBaseUser&lt;TKey&gt;<br>

### **ModularBaseUser(IModularBaseUser&lt;TKey&gt;)**

```csharp
public ModularBaseUser(IModularBaseUser<TKey> data)
```

#### Parameters

`data` IModularBaseUser&lt;TKey&gt;<br>

### **ModularBaseUser(Object)**

```csharp
public ModularBaseUser(object o)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

---

[`< Back`](./)
