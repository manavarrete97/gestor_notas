using gestor_notas.DTO;
using gestor_notas.Manager;
using gestor_notas.DAO.Interface;
using gestor_notas.Common.Interface;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas_test
{
 [TestFixture]
 public class PostProfesorManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IPostProfesorDAO> _postProfesorDAOMock;
 private PostProfesorManager _postProfesorManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _postProfesorDAOMock = new Mock<IPostProfesorDAO>();
 _postProfesorManager = new PostProfesorManager(_postgresConnectionMock.Object, _postProfesorDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task AddProfesorAsync_ShouldReturnTrue_WhenDAOOperationSucceeds()
 {
 // Arrange
 var profesorDTO = new ProfesorDTO { Nombre = "Juan Pérez" };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _postProfesorDAOMock.Setup(p => p.PostProfesor(It.IsAny<NpgsqlConnection>(), profesorDTO)).ReturnsAsync(true);

 // Act
 var result = await _postProfesorManager.AddProfesorAsync(profesorDTO);

 // Assert
 Assert.That(result, Is.True);
 }

 [Test]
 public async Task AddProfesorAsync_ShouldThrowException_WhenDAOOperationFails()
 {
 // Arrange
 var profesorDTO = new ProfesorDTO { Nombre = "Juan Pérez" };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _postProfesorDAOMock.Setup(p => p.PostProfesor(It.IsAny<NpgsqlConnection>(), profesorDTO)).ThrowsAsync(new System.Exception("Database error"));

 // Act & Assert
 Assert.ThrowsAsync<System.Exception>(async () => await _postProfesorManager.AddProfesorAsync(profesorDTO));
 }
 }
}