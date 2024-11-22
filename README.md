# DTOMaker

todo badge

*Warning: This is pre-release software under active development. Not for production use. Breaking changes occur often.*

This repo contains several related packages.

## DTOMaker.Models
Attributes for defining simple data models as interfaces in C#.

## DTOMaker.Core
Core types used by source generators at compile-time, including a common syntax receiver, and a powerful template processor.

## Generators
The following source generators depend on this package:

### DTOMaker.MessagePack
Generates DTOs decorated with MessagePack attributes (https://github.com/MessagePack-CSharp/MessagePack-CSharp).

### DTOMaker.MemBlocks
Generates DTOs whose internal data is a single memory block (Memory\<byte\>). Property getters and setters decode and encode
values directly to the block with explicit byte ordering (little-endian or big-endian).

### DTOMaker.CSPoco
Generates basic POCOs (Plain Old C# Objects) that implement the data model interfaces.

## Features

Features implemented:
- Data types: Boolean, S/Byte, U/Int16/32/64/128, Double, Single, Half, Char, Guid, Decimal
- IFreezable support
- Templates as code, template processing
- [Obsolete] members
- Fixed length arrays of above types
- DTOMaker.MessagePack source generator
- DTOMaker.MemBlocks source generator
- DTOMaker.CSPoco source generator

Features not implemented:
- Nullable types. T? can be simulated using a pair of fields (Boolean, T).
- Enum data types. An enumeration type can be simulated with a casting property.
- Strings (UTF8). String types can be simulated with a byte array field and a length field.

In progress:
- Json (NewtonSoft) generator

Coming next:
- Json (System.Text) generator
- ProtobufNet 3.0 generator
- other model entities
- member wire names and tags
- reservation (hidden members)
- compact layout method

Coming later:
- C# records generator
- Google Protobuf .proto generation
- polymorphic types
- generic patterns: lists, trees, unions, etc.
- variable length arrays
- logical value equality

These models are consumed by the following source generators to emit DTO classes that implement the 
model interfaces.

## Benchmarks

Some benchmarking comparing the serialization and deserialization performance of various generated DTOs can
be found at: todo