﻿namespace Randori

[<AutoOpen>]
module Say =

  let hello name =
    sprintf "Hello %s" name
