[`< Back`](./)

---

# ModularBaseUserClaim&lt;TKey&gt;

Namespace: Jlw.Extensions.Identity

EntityType that represents one specific user claim

```csharp
public class ModularBaseUserClaim<TKey> : 
```

#### Type Parameters

`TKey`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → IdentityUserClaim&lt;TKey&gt; → [ModularBaseUserClaim&lt;TKey&gt;](./jlw.extensions.identity.modularbaseuserclaim-1.md)

## Properties

### **Id**

```csharp
public int Id { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **UserId**

```csharp
public TKey UserId { get; set; }
```

#### Property Value

TKey<br>

### **ClaimType**

```csharp
public string ClaimType { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ClaimValue**

```csharp
public string ClaimValue { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **ModularBaseUserClaim(IdentityUserClaim&lt;TKey&gt;)**

```csharp
public ModularBaseUserClaim(IdentityUserClaim<TKey> claim)
```

#### Parameters

`claim` IdentityUserClaim&lt;TKey&gt;<br>

### **ModularBaseUserClaim(Object)**

```csharp
public ModularBaseUserClaim(object o)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

## Methods

### **CopyFrom(IdentityUserClaim&lt;TKey&gt;)**

```csharp
public ModularBaseUserClaim<TKey> CopyFrom(IdentityUserClaim<TKey> claim)
```

#### Parameters

`claim` IdentityUserClaim&lt;TKey&gt;<br>

#### Returns

[ModularBaseUserClaim&lt;TKey&gt;](./jlw.extensions.identity.modularbaseuserclaim-1.md)<br>

### **CopyFrom(Object)**

```csharp
public ModularBaseUserClaim<TKey> CopyFrom(object o)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[ModularBaseUserClaim&lt;TKey&gt;](./jlw.extensions.identity.modularbaseuserclaim-1.md)<br>

---

[`< Back`](./)
