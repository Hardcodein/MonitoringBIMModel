namespace TrackingChangesBimModel.RevitPlugin.Services;

internal class GeometreyProvider : IGeometryProvider
{
    private readonly XyzEqualityComparer EqualityComparer;

    public GeometreyProvider(XyzEqualityComparer xyzEqualityComparer)
    {
        EqualityComparer = xyzEqualityComparer;
    }

    public List<XYZ> GetCanonicVertices(Element element)
    {
        var geo = element.get_Geometry(new Options());
        var transform = Transform.Identity;

        Dictionary<XYZ, int> vertexLookup
          = new Dictionary<XYZ, int>(
            EqualityComparer);

        AddVertices(vertexLookup, transform, geo);
        var keys = new List<XYZ>(vertexLookup.Keys);

        keys.Sort(GeometricalComparison.Compare);

        return keys;
    }

    private void AddVertices(Dictionary<XYZ, int> vertexLookup, Transform transform, GeometryElement geoELement)
    {
        if (geoELement is null)
        {
            throw new ArgumentException("GeometryElement is null");
        }

        foreach (var obj in geoELement)
        {
            var solid = obj as Solid;

            if (solid is not null)
            {
                if (0 < solid.Faces.Size)
                {
                    AddVertices(vertexLookup, transform, solid);
                }


            }
            else
            {
                var inst = obj as GeometryInstance;

                if (inst is not null)
                {
                    GeometryElement geos = inst.GetSymbolGeometry();

                    if (geos is not null)
                    {
                        AddVertices(vertexLookup, inst.Transform.Multiply(transform), geos);
                    }
                }
            }
        }
    }

    private void AddVertices(Dictionary<XYZ, int> vertexLookup, Transform transform, Solid solid)
    {
        foreach (Face face in solid.Faces)
        {
            Mesh mesh = face.Triangulate();

            if (mesh is null)
            {
                return;
            }

            foreach (XYZ p in mesh.Vertices)
            {
                XYZ q = transform.OfPoint(p);

                if (!vertexLookup.ContainsKey(q))
                {
                    vertexLookup.Add(q, 1);
                }
                else
                {
                    ++vertexLookup[q];
                }
            }

        }
    }
}