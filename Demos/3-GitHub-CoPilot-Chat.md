# Start explaining CoPilot chat window

...

# Interaction 1 (Explain the selected code)

**Question 1**

1. Select `PlaneController.cs`

```
Can you explain the selected file?
```

# Feature 1 (Explain)

1. Select a the piece of code

2. CoPilot -> Explain this

# Interaction 2 (Create unit tests):

1. Select code snippet in `PlaneController.cs`

**Question 1**

```
Can you create unit tests for the selected file?
```

# Feature 2 (Generate Tests)

1. Select a piece of code

2. CoPilot -> Generate Tests

## Feature 3 (Fix This)

1. Add some wrong code

Note the `p.Year == name`

```
[HttpGet("name/{name}")]
public ActionResult<Plane> Get(string name)
{
    var plane = Planes.Find(p => p.Year == name);
    if (plane == null)
    {
        return NotFound();
    }
    return plane;
}
```

2. CoPilot -> Fix This

## Feature 4 (Generate Docs)

1. Select a piece of code

2. CoPilot -> Generate Tests
