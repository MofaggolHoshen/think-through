using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenariosTest;

[TestClass]
public class CloneOrCopyObjectTest
{
    [TestMethod]
    public void ICloneableTest()
    {
        var (originalObj, clonedObj) = ICloneableHelper();
       
        Assert.IsFalse(originalObj.Name == clonedObj.Name);
        Assert.IsFalse(originalObj.Equals(clonedObj));
    }

    [TestMethod]
    public void CloneTest()
    {
        var (originalObj, clonedObj) = CloneHelper();

        Assert.IsFalse(originalObj.Name == clonedObj.Name);
        Assert.IsFalse(originalObj.Equals(clonedObj));
    }

    public Tuple<CloneOrCopyObj1, CloneOrCopyObj1> ICloneableHelper()
    {
        var cloneOrCopObj1 = new CloneOrCopyObj1()
        {
            Name = "Mofaggol Hoshen",
            Address = new CloneOrCopyObj2()
            {
                City = "Mymensingh",
                Street = "Sutiakhali"
            },
            Age = 30
        };

        var clonedObj1 = (CloneOrCopyObj1)cloneOrCopObj1.Clone();
        clonedObj1.Name = "Mofaggol Ibne Jolil";

        return new Tuple<CloneOrCopyObj1, CloneOrCopyObj1>(cloneOrCopObj1, clonedObj1);
    }

    public Tuple<CloneOrCopyObj3, CloneOrCopyObj3> CloneHelper()
    {
        var cloneOrCopObj = new CloneOrCopyObj3()
        {
            Name = "Mofaggol Hoshen",
            Address = new CloneOrCopyObj4()
            {
                City = "Mymensingh",
                Street = "Sutiakhali"
            },
            Age = 30
        };

        var clonedObj = cloneOrCopObj.Clone();
        clonedObj.Name = "Mofaggol Ibne Jolil";

        return new Tuple<CloneOrCopyObj3, CloneOrCopyObj3>(cloneOrCopObj, clonedObj);
    }
}

public class CloneOrCopyObj1 : ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public CloneOrCopyObj2 Address { get; set; }

    public object Clone()
    {
        var clonedObj = (CloneOrCopyObj1)MemberwiseClone();
        clonedObj.Address = (CloneOrCopyObj2)Address.Clone();
        return clonedObj;
    }
}

public class CloneOrCopyObj2 : ICloneable
{
    public string City { get; set; }
    public string Street { get; set; }

    public object Clone()
    {
        return MemberwiseClone();
    }
}

public class CloneOrCopyObj3
{
    public string Name { get; set; }
    public int Age { get; set; }
    public CloneOrCopyObj4 Address { get; set; }

    public CloneOrCopyObj3 Clone()
    {
        var clonedObj = (CloneOrCopyObj3)MemberwiseClone();
        clonedObj.Address = Address.Clone();
        return clonedObj;
    }
}

public class CloneOrCopyObj4
{
    public string City { get; set; }
    public string Street { get; set; }

    public CloneOrCopyObj4 Clone()
    {
        return (CloneOrCopyObj4)MemberwiseClone();
    }
}
